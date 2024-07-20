using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MovieService.Data.MovieData;
using MovieService.Dtos.MovieDTO;
using MovieService.Models;
using System.Net;

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
        public IActionResult GetAllMovie()
        {
            var movieItem = _repository.GetAll();
            var mapToDTO = _mapper.Map<IEnumerable<MovieReadDTO>>(movieItem);
            return CustomResult("Data load successfully", mapToDTO);
        }

        [HttpPost]
        public ActionResult<MovieReadDTO> InsertMovie(MovieCreateDTO movieCreateDTO)
        {
            Movies movie = _mapper.Map<Movies>(movieCreateDTO);
            _repository.InsertMovie(movie);
            _repository.saveChange();

            MovieReadDTO movieReadDTO = _mapper.Map<MovieReadDTO>(movie);

            return Ok(movieReadDTO);

        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            try
            {
                Movies movie = _repository.GetById(id);
                if (movie == null)
                {
                    return CustomResult("Movie not found", HttpStatusCode.BadRequest);
                }
                return CustomResult("Movie found", _mapper.Map<MovieReadDTO>(movie));
            }
            catch(IOException e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<MovieReadDTO> UpdateMovie(int id, MovieCreateDTO movieCreateDTO)
        {
            var existingMovie = _repository.GetById(id);
            if (existingMovie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieCreateDTO, existingMovie);
            _repository.Update(id, existingMovie);
            MovieReadDTO updatedMovieDto = _mapper.Map<MovieReadDTO>(existingMovie);
            return Ok(updatedMovieDto);
        }

    }
}
