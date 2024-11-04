using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application;

namespace TurnosPadel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAutenticacionService _authService;

        public AuthController(IAutenticacionService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] QuestionDto loginDto)
        {
            var response = _authService.Authenticate(loginDto);

            if (response == null)
            {
                return Unauthorized("DNI o contraseña incorrectos");
            }

            return Ok(response);
        }

    }
}
