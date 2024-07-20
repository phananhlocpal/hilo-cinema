using AutoMapper;
using CustomerService.Data;
using CustomerService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var customer = _repository.GetAll();
                if (!customer.Any())
                {
                    return BadRequest("Customer list is empty");
                }
                return Ok(_mapper.Map<IEnumerable<CustomerReadDTO>>(customer));
            }
            catch (IOException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
