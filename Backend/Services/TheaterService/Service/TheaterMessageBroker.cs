using AutoMapper;
using System.Text;
using System.Text.Json;
using TheaterService.Data;
using TheaterService.Dtos;

namespace TheaterService.Service
{
    public class TheaterMessageBroker : MessageService, IHostedService
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public TheaterMessageBroker(ILogger<MessageService> logger, IMapper mapper, IServiceScopeFactory scopeFactory)
            : base(logger)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;

            DeclareQueue("theater_request");
            DeclareQueue("theater_response");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ConsumeMessage("movie_request", async (model, ea) =>
            {
                using var scope = _scopeFactory.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<ITheaterRepo>();

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"Received Message: {message}");

                try
                {
                    var theaterRequest = JsonSerializer.Deserialize<TheaterRequest>(message);
                    var theater = repository.getTheaterById(theaterRequest.TheaterId);
                    var theaterDto = _mapper.Map<TheaterReadDto>(theater);

                    PublishMessage(ea.BasicProperties.ReplyTo, theaterDto, ea.BasicProperties.CorrelationId);
                }
                catch (JsonException jsonEx)
                {
                    _logger.LogError($"JSON Deserialization error: {jsonEx.Message}");
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }

        public class TheaterRequest
        {
            public int TheaterId { get; set; }
        }
    }
}
