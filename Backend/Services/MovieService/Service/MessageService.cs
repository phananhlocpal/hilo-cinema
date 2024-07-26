using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GenericService.Service
{
    public abstract class MessageService<TRequest, TResponse> : BackgroundService
    {
        private readonly ILogger<MessageService<TRequest, TResponse>> _logger;
        protected readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string _requestQueue;
        private readonly string _responseQueue;
        private IModel _channel;

        protected MessageService(
            ILogger<MessageService<TRequest, TResponse>> logger,
            IMapper mapper,
            IServiceScopeFactory scopeFactory,
            string requestQueue,
            string responseQueue)
        {
            _logger = logger;
            _mapper = mapper;
            _scopeFactory = scopeFactory;
            _requestQueue = requestQueue;
            _responseQueue = responseQueue;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Port = 5672,
                Password = "admin",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: _requestQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: _responseQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Received Message: {message}");

                    try
                    {
                        var request = JsonSerializer.Deserialize<TRequest>(message);
                        _logger.LogInformation($"Deserialized Request: {JsonSerializer.Serialize(request)}");

                        var response = await HandleMessageAsync(scope, request);

                        var replyProps = _channel.CreateBasicProperties();
                        replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

                        _channel.BasicPublish(
                            exchange: "",
                            routingKey: ea.BasicProperties.ReplyTo,
                            basicProperties: replyProps,
                            body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response)));
                    }
                    catch (JsonException jsonEx)
                    {
                        _logger.LogError($"JSON Deserialization error: {jsonEx.Message}");
                    }
                }
            };

            _channel.BasicConsume(queue: _requestQueue, autoAck: true, consumer: consumer);
        }

        protected abstract Task<TResponse> HandleMessageAsync(IServiceScope scope, TRequest request);

        public override void Dispose()
        {
            _channel?.Dispose();
            base.Dispose();
        }
    }
}
