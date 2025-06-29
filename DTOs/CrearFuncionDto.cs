using System.ComponentModel.DataAnnotations;

namespace CineCartelera.API.DTOs
{
    public class CrearFuncionDto
    {
        [Required]
        public int PeliculaId { get; set; }

        [Required]
        public int SalaId { get; set; }

        [Required]
        public DateTime HoraInicio { get; set; }

        [Required]
        public DateTime HoraFin { get; set; }

        [Required]
        public int Capacidad { get; set; }
    }
}
