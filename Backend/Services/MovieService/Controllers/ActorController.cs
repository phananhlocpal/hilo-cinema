using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MovieService.Data.ActorData;
using MovieService.Data.Producer;
using MovieService.Dtos.ActorDTO;

using MovieService.Models;

namespace MovieService.Controllers
{
    [Route("api/ActorService")]
    public class ActorController : BaseController
    {
        private readonly IActorRepository _repository;
        private readonly IMapper _mapper;

        public ActorController(IActorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var actorItem = _repository.GetAll();
                if (!actorItem.Any())
                {
                    return CustomResult("Actor list is empty", System.Net.HttpStatusCode.BadRequest);
                }
                return CustomResult("Get Data Successfully", _mapper.Map<IEnumerable<ActorReadDTO>>(actorItem));
            }
            catch(IOException e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult InsertActor(ActorCreateDTO actorCreateDTO)
        {
            try
            {
                Actor actor = _mapper.Map<Actor>(actorCreateDTO);
                _repository.InsertActor(actor);
                _repository.saveChange();

                ActorReadDTO actorReadDTO = _mapper.Map<ActorReadDTO>(actor);

                return CustomResult("Create actor successfully", actorReadDTO, System.Net.HttpStatusCode.Created);
            }
            catch(IOException e)
            {
                return BadRequest(e.Message);
            }
            

        }

        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
            Actor actor = _repository.GetById(id);
            if (actor == null)
            {
                return CustomResult("Actor does not exist", System.Net.HttpStatusCode.NotFound);
            }
            return CustomResult("Get actor successfully",_mapper.Map<ActorReadDTO>(actor));
        }

        [HttpPut("{id}")]
        public ActionResult<ActorReadDTO> UpdateActor(int id, ActorCreateDTO actorCreateDTO)
        {
            var existingActor = _repository.GetById(id);
            if (existingActor == null)
            {
                return NotFound();
            }
            _mapper.Map(actorCreateDTO, existingActor);
            _repository.Update(id, existingActor);
            ActorReadDTO actorReadDTO = _mapper.Map<ActorReadDTO>(existingActor);
            return Ok(actorReadDTO);
        }
    }
}
