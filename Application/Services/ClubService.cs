using Domain;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClubService
    {
        private readonly IClubRepository _clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public void InicializarCanchasParaClub(Club club, int cantidadDeCanchas)
        {
            for (int i = 0; i < cantidadDeCanchas; i++)
            {
                var cancha = new Cancha
                {
                    ClubId = club.Id,
                    Turnos = TurnoPredefinido.ObtenerTurnosPredefinidos()
                };
                club.Canchas.Add(cancha);
            }
            _clubRepository.Crear(club);
        }

        public Club ObtenerClubPorId(int id)
        {
            return _clubRepository.ObtenerPorId(id);
        }

        public List<Club> ObtenerTodosLosClubes()
        {
            return _clubRepository.ObtenerTodos();
        }

        public void ActualizarClub(Club club)
        {
            _clubRepository.Actualizar(club);
        }

        public void EliminarClub(int id)
        {
            _clubRepository.Eliminar(id);
        }
    }
}
