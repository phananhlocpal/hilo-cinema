using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using ScheduleService.Dtos;
using Microsoft.Extensions.Logging; 

namespace ScheduleService.Service
{
    public class ScheduleSubcriber
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ILogger<ScheduleSubcriber> _logger; 

        public ScheduleSubcriber(ILogger<ScheduleSubcriber> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Port = 5672,
                Password = "admin",
                VirtualHost = "/"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "movie_response", durable: false, exclusive: false, autoDelete: false, arguments: null); // Ensure this queue is declared
        }

        public async Task<MovieReadDto> GetMovieByIdAsync(int movieId)
        {
            var tcs = new TaskCompletionSource<MovieReadDto>();

            var correlationId = Guid.NewGuid().ToString();
            var props = _channel.CreateBasicProperties();
            props.CorrelationId = correlationId;
            props.ReplyTo = "movie_response";

            var request = new { MovieId = movieId };
            var messageBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

            _logger.LogInformation("Sending message: {Message}", Encoding.UTF8.GetString(messageBytes)); 
            _channel.BasicPublish(exchange: "", routingKey: "movie_request", basicProperties: props, body: messageBytes);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var movieDto = JsonSerializer.Deserialize<MovieReadDto>(message);

                _logger.LogInformation("Received message: {Message}", message); 

                tcs.SetResult(movieDto);
            };

            _channel.BasicConsume(queue: "movie_response", autoAck: true, consumer: consumer);


            return await tcs.Task;
        }
    }
}
