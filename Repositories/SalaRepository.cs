using CineCartelera.API.Data;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CineCartelera.API.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sala>> ObtenerTodasAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala?> ObtenerPorIdAsync(int id)
        {
            return await _context.Salas.FindAsync(id);
        }

        public Task AgregarAsync(Sala sala)
        {
            _context.Salas.Add(sala);
            return Task.CompletedTask;
        }

        public Task ActualizarAsync(Sala sala)
        {
            _context.Salas.Update(sala);
            return Task.CompletedTask;
        }

        public async Task EliminarAsync(int id)
        {
            var sala = await ObtenerPorIdAsync(id);
            if (sala != null)
                _context.Salas.Remove(sala);
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
