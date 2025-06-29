using System.ComponentModel.DataAnnotations;

namespace CineCartelera.API.DTOs
{
    public class CrearReservaDto
    {
        [Required]
        public int FuncionId { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string TipoDocumento { get; set; }

        [Required]
        public string NumeroDocumento { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefono { get; set; }
    }
}
