using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TurnosPadel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly ClubService _clubService;

        public ClubController(ClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpPost]
        public IActionResult CrearClub([FromBody] Club club)
        {
            _clubService.InicializarCanchasParaClub(club, club.NumeroDeCanchas);
            return Ok(club);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerClubPorId(int id)
        {
            var club = _clubService.ObtenerClubPorId(id);
            if (club == null)
                return NotFound();

            return Ok(club);
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosClubes()
        {
            var clubes = _clubService.ObtenerTodosLosClubes();
            return Ok(clubes);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarClub(int id, [FromBody] Club clubActualizado)
        {
            var club = _clubService.ObtenerClubPorId(id);
            if (club == null)
                return NotFound();

            club.Nombre = clubActualizado.Nombre;
            club.NumeroDeCanchas = clubActualizado.NumeroDeCanchas;
            club.CVU = clubActualizado.CVU;
            club.Descripcion = clubActualizado.Descripcion;
            club.Email = clubActualizado.Email;

            _clubService.ActualizarClub(club);
            return Ok(club);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarClub(int id)
        {
            var club = _clubService.ObtenerClubPorId(id);
            if (club == null)
                return NotFound();

            _clubService.EliminarClub(id);
            return NoContent();
        }
    }
}

