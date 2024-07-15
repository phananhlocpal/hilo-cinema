using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.RabbitMq
{
    class RabbitMqPersitentConnection : IRabbitMqPersitentConnection
    {
        private readonly IConnectionFactory _connectioFactory;
        private readonly ILogger<RabbitMqPersitentConnection> _logger;
        private readonly int _retryCount;
        private IConnection _connection;
        private bool _disposed;
        private readonly object syncRoot = new object();

        public RabbitMqPersitentConnection(IConnectionFactory connectioFactoryn, ILogger<RabbitMqPersitentConnection> logger, int retryCount = 5)
        {
            _connectioFactory = connectioFactoryn;
            _logger = logger;
            _retryCount = retryCount;
        }
        public bool IsConnected => _connection != null && _connection.IsOpen && _disposed;

        public IModel CreateModel()
        {
            if (!IsConnected)
                throw new InvalidOperationException("No Rabbit Mq connections are available to perform this action!");
            return _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            try
            {
                _connection.Dispose(); ;
            }
            catch (IOException ex) 
            {
                _logger.LogCritical(ex.ToString());
            }
        } 

        public bool TryConnect()
        {
            _logger.LogInformation("RabbitMq Client is trying to connect");
            lock(syncRoot)
            {
                var policy = RetryPolicy
                    .Handle<SocketException>()
                    .Or<BrokerUnreachableException>()
                    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    _logger.LogWarning(ex, "RabbitMq Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                    });
                policy.Execute(() =>
                {
                    _connection = _connectioFactory.CreateConnection();
                });
                if (IsConnected)
                {
                    _connection.ConnectionShutdown += OnConnectionShutdown;
                    _connection.CallbackException += OnCallBackException;
                    _connection.ConnectionBlocked += OnConnectionBlocked;

                    _logger.LogInformation("RabbitMQ Client acquired a persitent connection to '{HostName}' and is subcribed to failure events", _connection.Endpoint.HostName);
                    return true;
                }   
                else
                {
                    _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created an opened");

                    return false;
                }
            }
        }

        private void OnConnectionBlocked(object? sender, ConnectionBlockedEventArgs e)
        {
            if (_disposed) return;
            _logger.LogWarning("A RabbitMQ connection is shutdown. Try to reconenct ...");
            TryConnect();
        }

        private void OnCallBackException(object? sender, CallbackExceptionEventArgs e)
        {
            if (_disposed) return ;
            _logger.LogWarning("A RabbitMQ connection throw exception. Trying to reconnect ...");
            TryConnect();
        }

        private void OnConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            if (_disposed) return;
            _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to reconnect ...");
            TryConnect();
        }
    }
}
