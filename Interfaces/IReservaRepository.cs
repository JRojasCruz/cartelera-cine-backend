using CineCartelera.API.Models;

namespace CineCartelera.API.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> ObtenerTodasAsync();
        Task<Reserva?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Reserva reserva);
        Task<bool> GuardarCambiosAsync();
    }
}
