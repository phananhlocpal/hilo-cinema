using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieService.Data.MovieData;
using MovieService.Dtos.MovieDTO;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MovieService.Service
{
    public class MovieMessageBroker : MessageService, IHostedService
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public MovieMessageBroker(ILogger<MessageService> logger, IMapper mapper, IServiceScopeFactory scopeFactory)
            : base(logger)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;

            DeclareQueue("movie_request");
            DeclareQueue("movie_response");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ConsumeMessage("movie_request", async (model, ea) =>
            {
                using var scope = _scopeFactory.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"Received Message: {message}");

                try
                {
                    var movieRequest = JsonSerializer.Deserialize<MovieRequest>(message);
                    var movie = await repository.GetByIdAsync(movieRequest.MovieId);
                    var movieDto = _mapper.Map<MovieReadDTO>(movie);

                    PublishMessage(ea.BasicProperties.ReplyTo, movieDto, ea.BasicProperties.CorrelationId);
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

        public class MovieRequest
        {
            public int MovieId { get; set; }
        }
    }
}
