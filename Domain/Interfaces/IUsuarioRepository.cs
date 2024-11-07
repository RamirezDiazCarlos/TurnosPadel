using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario ObtenerPorId(int id);
        Usuario ObtenerPorEmail(string email);
        List<Usuario> ObtenerTodos();
        void Crear(Usuario usuario);
        void Actualizar(Usuario usuario);
        void Eliminar(int id);
        Usuario ObtenerPorDni(string id);
        void SaveChanges();
    }
}

