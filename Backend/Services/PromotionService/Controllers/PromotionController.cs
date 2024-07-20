using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromotionService.Data;
using PromotionService.Dtos;
using PromotionService.Models;
using System.Net;

namespace PromotionService.Controllers
{
    [Route("api/PromotionService")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;

        public PromotionController(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var promotionItem = _repository.GetAll();
                var mapToDTO = _mapper.Map<IEnumerable<PromotionReadDTO>>(promotionItem);
                return Ok(mapToDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<PromotionReadDTO> InsertMovie(PromotionCreateDTO promotionCreate)
        {
            try
            {
                Promotion promotion = _mapper.Map<Promotion>(promotionCreate);
                _repository.Insert(promotion);

                PromotionReadDTO promotionReadDTO = _mapper.Map<PromotionReadDTO>(promotion);

                return Ok(promotionReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            try
            {
                Promotion promotion = _repository.GetById(id);
                if (promotion == null)
                {
                    return BadRequest("Promotion not found");
                }
                return Ok(_mapper.Map<PromotionReadDTO>(promotion));
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult<PromotionReadDTO> UpdateMovie(PromotionCreateDTO promotionCreateDTO)
        {
            try
            {
                var existingPromotion = _repository.GetById(promotionCreateDTO.Id);
                if (existingPromotion == null)
                {
                    return NotFound();
                }
                _mapper.Map(promotionCreateDTO, existingPromotion);
                _repository.Update(existingPromotion);
                PromotionReadDTO update = _mapper.Map<PromotionReadDTO>(existingPromotion);
                return Ok(update);
            }catch(IOException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
