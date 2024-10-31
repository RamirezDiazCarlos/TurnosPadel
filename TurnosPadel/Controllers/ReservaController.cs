using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TurnosPadel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerReserva(int id)
        {
            var reserva = _reservaRepository.ObtenerPorId(id);
            if (reserva == null) return NotFound();
            return Ok(reserva);
        }

        [HttpPost]
        public IActionResult CrearReserva([FromBody] Reserva reserva)
        {
            _reservaRepository.Crear(reserva);
            return CreatedAtAction(nameof(ObtenerReserva), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarReserva(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.Id) return BadRequest();
            _reservaRepository.Actualizar(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            _reservaRepository.Eliminar(id);
            return NoContent();
        }
    }
}
