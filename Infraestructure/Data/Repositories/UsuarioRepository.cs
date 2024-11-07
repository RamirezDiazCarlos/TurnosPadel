using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PadelDbContext _context;

        public UsuarioRepository(PadelDbContext context)
        {
            _context = context;
        }

        public Usuario ObtenerPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario ObtenerPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _context.Usuarios.ToList();
        }

        public void Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Eliminar(int id)
        {
            var usuario = ObtenerPorId(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
        }

        public Usuario ObtenerPorDni(string dni)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Dni == dni);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}