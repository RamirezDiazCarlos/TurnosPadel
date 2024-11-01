using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CanchaService
    {
        private readonly ICanchaRepository _canchaRepository;

        public CanchaService(ICanchaRepository canchaRepository)
        {
            _canchaRepository = canchaRepository;
        }

        public Cancha ObtenerCanchaPorId(int id)
        {
            return _canchaRepository.ObtenerPorId(id);
        }

        public List<Cancha> ObtenerCanchasPorClubId(int clubId)
        {
            return _canchaRepository.ObtenerPorClubId(clubId);
        }

        public List<Cancha> ObtenerTodasLasCanchas()
        {
            return _canchaRepository.ObtenerTodas();
        }

        public void CrearCancha(Cancha cancha)
        {
            _canchaRepository.Crear(cancha);
        }

        public void ActualizarCancha(Cancha cancha)
        {
            _canchaRepository.Actualizar(cancha);
        }

        public void EliminarCancha(int id)
        {
            _canchaRepository.Eliminar(id);
        }
    }
}

