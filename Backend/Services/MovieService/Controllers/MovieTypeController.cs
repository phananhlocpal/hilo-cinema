using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MovieService.Data.CategoryData;
using MovieService.Data.MovieTypeData;
using MovieService.Dtos.CategortDTO;
using MovieService.Dtos.MovieTypeDTO;
using MovieService.Models;

namespace MovieService.Controllers
{
    [Route("api/MovieTypeService")]
    [ApiController]
    public class MovieTypeController : BaseController
    {
        private readonly IMovieTypeRepository _repository;
        private readonly IMapper _mapper;

        public MovieTypeController(IMovieTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var type = _repository.GetAll();
                if (!type.Any())
                {
                    return CustomResult("Type list is empty", System.Net.HttpStatusCode.BadRequest);
                }
                return CustomResult("Get Data Successfully", _mapper.Map<IEnumerable<MovieTypeReadDTO>>(type));
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult InsertCategory(MovieTypeCreateDTO movieTypeCreateDTO)
        {
            try
            {
                MovieType type = _mapper.Map<MovieType>(movieTypeCreateDTO);
                _repository.Insert(type);
                _repository.saveChange();

                MovieTypeReadDTO movieTypeReadDTO = _mapper.Map<MovieTypeReadDTO>(type);

                return CustomResult("Create type successfully", movieTypeReadDTO, System.Net.HttpStatusCode.Created);
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
            MovieType type = _repository.GetById(id);
            if (type == null)
            {
                return CustomResult("Type does not exist", System.Net.HttpStatusCode.NotFound);
            }
            return CustomResult("Get Type successfully", _mapper.Map<MovieTypeReadDTO>(type));
        }

        [HttpPut("{id}")]
        public ActionResult<MovieTypeReadDTO> UpdateMovieType(int id, MovieTypeCreateDTO movieTypeCreateDTO)
        {
            var existingType = _repository.GetById(id);
            if (existingType == null)
            {
                return NotFound();
            }
            _mapper.Map(movieTypeCreateDTO, existingType);
            _repository.Update(id, existingType);
            MovieTypeReadDTO movieTypeReadDTO = _mapper.Map<MovieTypeReadDTO>(existingType);
            return Ok(movieTypeReadDTO);
        }
    }
}
