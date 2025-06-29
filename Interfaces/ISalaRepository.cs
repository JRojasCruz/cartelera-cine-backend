using CineCartelera.API.Models;

namespace CineCartelera.API.Interfaces
{
    public interface ISalaRepository
    {
        Task<IEnumerable<Sala>> ObtenerTodasAsync();
        Task<Sala?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Sala sala);
        Task ActualizarAsync(Sala sala);
        Task EliminarAsync(int id);
        Task<bool> GuardarCambiosAsync();
    }
}
