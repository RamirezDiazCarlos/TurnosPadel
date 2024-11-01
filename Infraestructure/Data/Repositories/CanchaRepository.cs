using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CanchaRepository : ICanchaRepository
{
    private readonly PadelDbContext _context;

    public CanchaRepository(PadelDbContext context)
    {
        _context = context;
    }

    public Cancha ObtenerPorId(int id)
    {
        return _context.Canchas.FirstOrDefault(c => c.Id == id);
    }

    public List<Cancha> ObtenerPorClubId(int clubId)
    {
        return _context.Canchas.Where(c => c.ClubId == clubId).ToList();
    }

    public List<Cancha> ObtenerTodas()
    {
        return _context.Canchas.ToList();
    }

    public void Crear(Cancha cancha)
    {
        _context.Canchas.Add(cancha);
        _context.SaveChanges();
    }

    public void Actualizar(Cancha cancha)
    {
        _context.Entry(cancha).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var cancha = _context.Canchas.FirstOrDefault(c => c.Id == id);
        if (cancha != null)
        {
            _context.Canchas.Remove(cancha);
            _context.SaveChanges();
        }
    }
}