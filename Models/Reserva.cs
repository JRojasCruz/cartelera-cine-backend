using System.ComponentModel.DataAnnotations;

namespace CineCartelera.API.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int FuncionId { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaReserva { get; set; } = DateTime.Now;

        public string NumeroTicket { get; set; }

        public Funcion Funcion { get; set; }
    }
}
