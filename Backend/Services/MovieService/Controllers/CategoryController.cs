

using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using MovieService.Data.ActorData;
using MovieService.Data.CategoryData;
using MovieService.Dtos.ActorDTO;
using MovieService.Dtos.CategortDTO;
using MovieService.Models;

namespace MovieService.Controllers
{
    [Route("api/CategoryService")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var category = _repository.GetAll();
                if (!category.Any())
                {
                    return CustomResult("Categories list is empty", System.Net.HttpStatusCode.BadRequest);
                }
                return CustomResult("Get Data Successfully", _mapper.Map<IEnumerable<CategoryReadDTO>>(category));
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult InsertCategory(CategoryCreateDTO categoryCreateDTO)
        {
            try
            {
                Category category = _mapper.Map<Category>(categoryCreateDTO);
                _repository.Insert(category);
                _repository.saveChange();

                CategoryReadDTO categoryReadDTO = _mapper.Map<CategoryReadDTO>(category);

                return CustomResult("Create actor successfully", categoryReadDTO, System.Net.HttpStatusCode.Created);
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _repository.GetById(id);
            if (category == null)
            {
                return CustomResult("Category does not exist", System.Net.HttpStatusCode.NotFound);
            }
            return CustomResult("Get Category successfully", _mapper.Map<CategoryReadDTO>(category));
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryReadDTO> UpdateCategory(int id, CategoryCreateDTO categoryCreateDTO)
        {
            var existingCategory = _repository.GetById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryCreateDTO, existingCategory);
            _repository.Update(id, existingCategory);
            CategoryReadDTO categoryReadDTO = _mapper.Map<CategoryReadDTO>(existingCategory);
            return Ok(categoryReadDTO);
        }
    }
}
