using Application.Models;
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
        public IActionResult Crear([FromBody] ClubDto clubDto)
        {
            var club = new Club
            {
                Id = clubDto.Id,
                Nombre = clubDto.Nombre,
                Descripcion = clubDto.Descripcion,
                CVU = clubDto.CVU,
                Email = clubDto.Email,
            };

            int cantidadDeCanchas = clubDto.NumeroDeCanchas;

            _clubService.CrearClub(club, cantidadDeCanchas);

            return CreatedAtAction(nameof(ObtenerClubPorId), new { id = club.Id }, club);
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

