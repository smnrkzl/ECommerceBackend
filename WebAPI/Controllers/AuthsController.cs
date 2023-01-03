using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;

        }
        [HttpPost("register")]
        public IActionResult Register(RegisterAuthDto registerDto)
        {
            var result = _authService.Register(registerDto);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")] 
        public IActionResult Login(LoginAuthDto loginDto)
        {
            var result = _authService.Login(loginDto);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }

    }
}
