
using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MovieService.Data.MovieData;
using MovieService.Dtos.MovieDTO;
using MovieService.Models;
using MovieService.Service;
using System.Net;
using System.Threading.Tasks;

namespace MovieService.Controllers
{
    [Route("api/MovieService")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovie()
        {
            var movieItems = await _repository.GetAllAsync();
            var mapToDTO = _mapper.Map<IEnumerable<MovieReadDTO>>(movieItems);
            return CustomResult("Data load successfully", mapToDTO);
        }

        [HttpPost]
        public async Task<ActionResult<MovieReadDTO>> InsertMovie(MovieCreateDTO movieCreateDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreateDTO);
            await _repository.InsertMovieAsync(movie);
            await _repository.SaveChangesAsync();

            var movieReadDTO = _mapper.Map<MovieReadDTO>(movie);
            return Ok(movieReadDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await _repository.GetByIdAsync(id);
                if (movie == null)
                {
                    return CustomResult("Movie not found", HttpStatusCode.BadRequest);
                }
                return CustomResult("Movie found", _mapper.Map<MovieReadDTO>(movie));
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieReadDTO>> UpdateMovie(int id, MovieCreateDTO movieCreateDTO)
        {
            var existingMovie = await _repository.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieCreateDTO, existingMovie);
            await _repository.UpdateAsync(id, existingMovie);

            var updatedMovieDto = _mapper.Map<MovieReadDTO>(existingMovie);
            return Ok(updatedMovieDto);
        }

    }
}
