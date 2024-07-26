using AutoMapper;
using MovieService.Data.MovieData;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using MovieService.Dtos.MovieDTO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GenericService.Service;

namespace MovieService.Service
{
    public class MovieService : MessageService<MovieService.MovieRequest, MovieReadDTO>
    {
        public MovieService(
            ILogger<MessageService<MovieRequest, MovieReadDTO>> logger,
            IMapper mapper,
            IServiceScopeFactory scopeFactory)
            : base(logger, mapper, scopeFactory, "movie_request", "movie_response")
        {
        }

        protected override async Task<MovieReadDTO> HandleMessageAsync(IServiceScope scope, MovieRequest request)
        {
            var repository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();
            var movie = await repository.GetByIdAsync(request.MovieId);
            return _mapper.Map<MovieReadDTO>(movie);
        }

        public class MovieRequest
        {
            public int MovieId { get; set; }
        }
    }
}
