using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Tel = usuario.Tel,
                Edad = usuario.Edad,
                Dni = usuario.Dni,
                Rol = usuario.Rol,
                PosicionEnCancha = usuario.PosicionEnCancha
            };

            return Ok(usuarioDto);
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosUsuarios()
        {
            var usuarios = _usuarioRepository.ObtenerTodos();

            var usuariosDto = usuarios.Select(usuario => new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Tel = usuario.Tel,
                Edad = usuario.Edad,
                Dni = usuario.Dni,
                Rol = usuario.Rol,
                PosicionEnCancha = usuario.PosicionEnCancha
            }).ToList();

            return Ok(usuariosDto);
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usuarioRepository.Crear(usuario);
            _usuarioRepository.SaveChanges();

            return CreatedAtAction(nameof(ObtenerUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioExistente = _usuarioRepository.ObtenerPorId(id);
            if (usuarioExistente == null) return NotFound();

            _usuarioRepository.Actualizar(usuario);
            _usuarioRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuarioExistente = _usuarioRepository.ObtenerPorId(id);
            if (usuarioExistente == null) return NotFound();

            _usuarioRepository.Eliminar(id);
            _usuarioRepository.SaveChanges();

            return NoContent();
        }
    }
}