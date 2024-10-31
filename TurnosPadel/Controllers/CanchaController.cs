using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TurnosPadel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanchaController : ControllerBase
    {
        private readonly ICanchaRepository _canchaRepository;

        public CanchaController(ICanchaRepository canchaRepository)
        {
            _canchaRepository = canchaRepository;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerCancha(int id)
        {
            var cancha = _canchaRepository.ObtenerPorId(id);
            if (cancha == null) return NotFound();
            return Ok(cancha);
        }

        [HttpPost]
        public IActionResult CrearCancha([FromBody] Cancha cancha)
        {
            _canchaRepository.Crear(cancha);
            return CreatedAtAction(nameof(ObtenerCancha), new { id = cancha.Id }, cancha);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarCancha(int id, [FromBody] Cancha cancha)
        {
            if (id != cancha.Id) return BadRequest();
            _canchaRepository.Actualizar(cancha);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCancha(int id)
        {
            _canchaRepository.Eliminar(id);
            return NoContent();
        }
    }
}
