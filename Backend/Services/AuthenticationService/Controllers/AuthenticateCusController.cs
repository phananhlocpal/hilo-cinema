using AuthenticationService.Data;
using AuthenticationService.Dtos;
using AuthenticationService.Helper;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateCusController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public AuthenticateCusController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            try
            {
                if (_repository.IsEmailExist(model.Email))
                    return BadRequest("Email already in use");

                var customer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    Birthdate = model.Birthdate,
                    Password = PasswordHasher.HashPassword(model.Password),
                    Created_Date = DateTime.UtcNow
                };

                _repository.Register(customer);

                return Ok(new { message = "Register successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(LoginDTO model)
        {
            var customer = await _repository.GetCustomerByEmail(model.Email);

            if (customer == null || !PasswordHasher.VerifyPassword(customer.Password, model.Password))
                return BadRequest(new { message = "Email hoặc mật khẩu không chính xác" });

            
            var token = _repository.GenerateJwtToken(customer);

            customer.Token = token;
            _repository.UpdateCustomer(customer);

            return Ok(new { token });
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutDTO model)
        {
            var customer = await _repository.GetCustomerByEmail(model.Email);

            if (customer == null)
                return BadRequest(new { message = "Invalid email" });

            // Invalidate the token
            _repository.InvalidateToken(customer);

            return Ok(new { message = "Logout successful" });
        }
    }
}
