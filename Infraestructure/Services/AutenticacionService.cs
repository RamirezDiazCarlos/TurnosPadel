using Application.Models;
using Application;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AutenticacionService : IAutenticacionService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _userRepository;

    public AutenticacionService(IConfiguration configuration, IUsuarioRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public ResponseDto Authenticate(QuestionDto request)
    {
        var usuario = _userRepository.ObtenerPorDni(request.Dni);
        if (usuario == null || usuario.Contrasena != request.Contrasena)
        {
            return null;
        }

        var token = GenerateJwtToken(usuario);

        return new ResponseDto
        {
            Token = token,
            Rol = usuario.Rol,
            UsuarioId = usuario.Id,
            Nombre = usuario.Nombre,
            Expiration = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiresInMinutes"]))
        };
    }

    private string GenerateJwtToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Dni),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Role, usuario.Rol)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiresInMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
