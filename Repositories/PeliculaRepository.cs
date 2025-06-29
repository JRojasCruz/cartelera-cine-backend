using CineCartelera.API.Data;
using CineCartelera.API.Interfaces;
using CineCartelera.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CineCartelera.API.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly ApplicationDbContext _context;

        public PeliculaRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> ObtenerTodasAsync()
        {
            return await _context.Peliculas
                .Include(p => p.Funciones)
                    .ThenInclude(f => f.Sala)
                .ToListAsync();
        }
        public async Task<Pelicula?> ObtenerPorIdAsync(int id)
        {
            return await _context.Peliculas
                .Include(p => p.Funciones)
                    .ThenInclude(f => f.Sala)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AgregarAsync(Pelicula pelicula)
        {
            await _context.Peliculas.AddAsync(pelicula);
        }

        public Task ActualizarAsync(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            return Task.CompletedTask;
        }

        public async Task EliminarAsync(int id)
        {
            var pelicula = await ObtenerPorIdAsync(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
            }
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
