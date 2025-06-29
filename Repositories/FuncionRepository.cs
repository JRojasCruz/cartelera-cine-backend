using CineCartelera.API.Data;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CineCartelera.API.Repositories
{
    public class FuncionRepository : IFuncionRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcion>> ObtenerTodasAsync()
        {
            return await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .ToListAsync();
        }

        public async Task<Funcion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .Include(f => f.Reservas)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Funcion>> ObtenerPorPeliculaIdAsync(int peliculaId)
        {
            return await _context.Funciones
                .Where(f => f.PeliculaId == peliculaId)
                .Include(f=>f.Pelicula)
                .Include(f => f.Sala)
                .ToListAsync();
        }

        public async Task AgregarAsync(Funcion funcion)
        {
            await _context.Funciones.AddAsync(funcion);
        }

        public Task ActualizarAsync(Funcion funcion)
        {
            _context.Funciones.Update(funcion);
            return Task.CompletedTask;
        }

        public async Task EliminarAsync(int id)
        {
            var funcion = await ObtenerPorIdAsync(id);
            if (funcion != null)
                _context.Funciones.Remove(funcion);
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
