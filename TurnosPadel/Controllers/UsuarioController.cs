using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TurnosPadel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = _usuarioRepository.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosUsuarios()
        {
            var usuarios = _usuarioRepository.ObtenerTodos();
            return Ok(usuarios);
        }


        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            _usuarioRepository.Crear(usuario);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            _usuarioRepository.Actualizar(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            _usuarioRepository.Eliminar(id);
            return NoContent();
        }
    }
}
