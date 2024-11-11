using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly PadelDbContext _context;

        public ClubRepository(PadelDbContext context)
        {
            _context = context;
        }

        public Club ObtenerPorId(int id)
        {
            return _context.Clubes.Include(c => c.Canchas).FirstOrDefault(c => c.Id == id);
        }

        public List<Club> ObtenerTodos()
        {
            return _context.Clubes.Include(c => c.Canchas).ToList();
        }

        public void CrearClub(Club club)
        {
            club.Id = 0;
            _context.Clubes.Add(club);
            _context.SaveChanges();
        }

        public void Actualizar(Club club)
        {
            _context.Clubes.Update(club);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var club = _context.Clubes.FirstOrDefault(c => c.Id == id);
            if (club != null)
            {
                _context.Clubes.Remove(club);
                _context.SaveChanges();
            }
        }
    }
}