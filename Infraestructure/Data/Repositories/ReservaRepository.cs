using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ReservaRepository : IReservaRepository
{
    private readonly PadelDbContext _context;

    public ReservaRepository(PadelDbContext context)
    {
        _context = context;
    }

    public Reserva ObtenerPorId(int id)
    {
        return _context.Reservas.FirstOrDefault(r => r.Id == id);
    }

    public List<Reserva> ObtenerPorUsuarioId(int usuarioId)
    {
        return _context.Reservas.Where(r => r.UsuarioId == usuarioId).ToList();
    }

    public List<Reserva> ObtenerPorCanchaId(int canchaId)
    {
        return _context.Reservas.Where(r => r.CanchaId == canchaId).ToList();
    }

    public void Crear(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        _context.SaveChanges();
    }

    public void Actualizar(Reserva reserva)
    {
        _context.Entry(reserva).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var reserva = _context.Reservas.FirstOrDefault(r => r.Id == id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }
    }
}
