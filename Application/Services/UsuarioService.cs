using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _usuarioRepository.ObtenerPorId(id);
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioRepository.ObtenerTodos();
        }

        public void CrearUsuario(Usuario usuario)
        {
            _usuarioRepository.Crear(usuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.Actualizar(usuario);
        }

        public void EliminarUsuario(int id)
        {
            _usuarioRepository.Eliminar(id);
        }
    }
}
