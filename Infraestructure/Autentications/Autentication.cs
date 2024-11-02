using Domain.Entities;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TurnosPadel.Infrastructure.Services
{
    public class Autentication
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly IConfiguration _config;

        public Autentication(UsuarioRepository usuarioRepository, IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _config = config;
        }

        public string Authenticate(string nombre, string contrasena)
        {
            // Verifica si el usuario existe y la contraseña es correcta
            var usuario = _usuarioRepository.GetUsuarioByCredentials(nombre, contrasena);
            if (usuario == null)
                return null;

            // Genera el token JWT
            return GenerateJwtToken(usuario);
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_config["JwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtSettings:ExpiresInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
