using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieService.Data.Producer;
using MovieService.Dtos.ProducerDTO;
using MovieService.Models;

namespace MovieService.Controllers
{
    [Route("api/ProducerService")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _repository;
        private readonly IMapper _mapper;

        public ProducerController(IProducerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProducerReadDTO>> GetAll()
        {
            var producerItem = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProducerReadDTO>>(producerItem));
        }

        [HttpPost]
        public ActionResult<ProducerReadDTO> InsertMovie(ProducerCreateDTO producerCreateDTO)
        {
            Producers producer = _mapper.Map<Producers>(producerCreateDTO);
            _repository.InsertProducer(producer);
            _repository.saveChange();

            ProducerReadDTO producerReadDTO = _mapper.Map<ProducerReadDTO>(producer);

            return Ok(producerReadDTO);

        }

        [HttpGet("{id}")]
        public ActionResult<ProducerReadDTO> GetProducerById(int id)
        {
            Producers producer = _repository.GetById(id);
            if (producer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProducerReadDTO>(producer));
        }

        [HttpPut("{id}")]
        public ActionResult<ProducerReadDTO> UpdateMovie(int id, ProducerCreateDTO producerCreateDTO)
        {
            var existingProducer = _repository.GetById(id);
            if (existingProducer == null)
            {
                return NotFound();
            }
            _mapper.Map(producerCreateDTO, existingProducer);
            _repository.UpdateProducer(id, existingProducer);
            ProducerReadDTO producerReadDTO = _mapper.Map<ProducerReadDTO>(existingProducer);
            return Ok(producerReadDTO);
        }
    }
}
