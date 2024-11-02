using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
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
            return _context.Usuarios.Find(email);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _context.Usuarios.ToList();
        }

        public void Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges(); // guardar cambios en la bd
        }

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
        public Usuario GetUsuarioByCredentials(string nombre, string contrasena)
        {

            return _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre && u.Contrasena == contrasena);
        }

    }
}
