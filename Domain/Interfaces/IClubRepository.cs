using Domain.Entities;


namespace Domain.Interfaces
{
    public interface IClubRepository
    {
        Club ObtenerPorId(int id);
        List<Club> ObtenerTodos();
        void Crear(Club club);
        void Actualizar(Club club);
        void Eliminar(int id);
    }
}
