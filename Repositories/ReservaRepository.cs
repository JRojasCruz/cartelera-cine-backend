using CineCartelera.API.Data;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CineCartelera.API.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasAsync()
        {
            return await _context.Reservas
                .Include(r => r.Funcion)
                .ThenInclude(f => f.Pelicula)
                .Include(r => r.Funcion.Sala)
                .ToListAsync();
        }

        public async Task<Reserva?> ObtenerPorIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Funcion)
                .ThenInclude(f => f.Pelicula)
                .Include(r => r.Funcion.Sala)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AgregarAsync(Reserva reserva)
        {
            reserva.NumeroTicket = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            reserva.FechaReserva = DateTime.Now;

            await _context.Reservas.AddAsync(reserva);
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
