using Microsoft.AspNetCore.Mvc;
using TurnosPadel.Infrastructure.Services;

[ApiController]
[Route("api/[controller]")]
public class AutenticationController : ControllerBase
{
    private readonly Autentication _authService;

    public AutenticationController(Autentication authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var token = _authService.Authenticate(request.Nombre, request.Contrasena);

        if (token == null)
            return Unauthorized("Usuario o contraseña incorrectos");

        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public string Nombre { get; set; }
    public string Contrasena { get; set; }
}
