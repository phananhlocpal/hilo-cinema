using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using ScheduleService.Dtos;
using Microsoft.Extensions.Logging; 

namespace ScheduleService.Service
{
    public class ScheduleMessageBroker : MessageService
    {
        public ScheduleMessageBroker(ILogger<MessageService> logger)
            : base(logger)
        {
            DeclareQueue("movie_response");
        }

        public async Task<MovieReadDto> GetMovieByIdAsync(int movieId)
        {
            var tcs = new TaskCompletionSource<MovieReadDto>();
            var correlationId = Guid.NewGuid().ToString();
            var request = new { MovieId = movieId };

            PublishMessage("movie_request", request, correlationId, "movie_response");

            ConsumeMessage("movie_response", (model, ea) =>
            {
                if (ea.BasicProperties.CorrelationId == correlationId)
                {
                    var body = ea.Body.ToArray();
                    var responseMessage = Encoding.UTF8.GetString(body);
                    var movieDto = JsonSerializer.Deserialize<MovieReadDto>(responseMessage);

                    _logger.LogInformation("Received message: {Message}", responseMessage);

                    tcs.SetResult(movieDto);
                }
            });

            return await tcs.Task;
        }
    }
}
