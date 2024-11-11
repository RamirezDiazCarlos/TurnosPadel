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
            _clubRepository.CrearClub(club);
        }

        public void CrearClub(Club club, int cantidadDeCanchas)
        {
            
            if (club == null)
            {
                throw new ArgumentNullException(nameof(club), "El club no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(club.Nombre))
            {
                throw new ArgumentException("El nombre del club no puede estar vacío.", nameof(club.Nombre));
            }

            InicializarCanchasParaClub(club, cantidadDeCanchas);

            _clubRepository.CrearClub(club);
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
