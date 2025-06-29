using CineCartelera.API.Models;

namespace CineCartelera.API.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<IEnumerable<Pelicula>> ObtenerTodasAsync();
        Task<Pelicula?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Pelicula pelicula);
        Task ActualizarAsync(Pelicula pelicula);
        Task EliminarAsync(int id);
        Task<bool> GuardarCambiosAsync();
    }
}
