using CineCartelera.API.Models;

namespace CineCartelera.API.Interfaces
{
    public interface IFuncionRepository
    {
        Task<IEnumerable<Funcion>> ObtenerTodasAsync();
        Task<Funcion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Funcion>> ObtenerPorPeliculaIdAsync(int peliculaId);
        Task AgregarAsync(Funcion funcion);
        Task ActualizarAsync(Funcion funcion);
        Task EliminarAsync(int id);
        Task<bool> GuardarCambiosAsync();
    }
}
