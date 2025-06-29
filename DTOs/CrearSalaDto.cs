using System.ComponentModel.DataAnnotations;

namespace CineCartelera.API.DTOs
{
    public class CrearSalaDto
    {
        [Required]
        public string Nombre { get; set; }
    }
}
