using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheaterService.Data;
using TheaterService.Dtos;
using TheaterService.Models;

namespace TheaterService.Controllers
{
    [Route("api/GetTheaterService")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterRepo _repository;
        private readonly IMapper _mapper;

        public TheaterController(ITheaterRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TheaterReadDto>> GetTheaters()
        {
            Console.WriteLine("--> Getting Theaters ... ");
            var theaterItem = _repository.getAllTheaters();
            return Ok(_mapper.Map<IEnumerable<TheaterReadDto>>(theaterItem));
        }

        [HttpGet("{id}", Name = "GetTheaterById")]
        public ActionResult<TheaterReadDto> GetTheaterById(int id)
        {
            var theaterItem = _repository.getTheaterById(id);
            if (theaterItem != null)
            {
                return Ok(_mapper.Map<TheaterReadDto>(theaterItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TheaterReadDto> CreateTheater(TheaterCreateDto theaterCreateDto)
        {
            var theaterModel = _mapper.Map<TheaterModel>(theaterCreateDto);
            _repository.createTheater(theaterModel);
            _repository.saveChange();

            var theaterReadDto = _mapper.Map<TheaterReadDto>(theaterModel);

            return CreatedAtRoute(nameof(GetTheaterById), new { Id = theaterReadDto.Id }, theaterReadDto);
        }
    }
}
