using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICanchaRepository
    {
        Cancha ObtenerPorId(int id);
        List<Cancha> ObtenerPorClubId(int clubId);
        List<Cancha> ObtenerTodas();
        void Crear(Cancha cancha);
        void Actualizar(Cancha cancha);
        void Eliminar(int id);
    }
}
