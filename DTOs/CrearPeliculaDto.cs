using System.ComponentModel.DataAnnotations;

namespace CineCartelera.API.DTOs
{
    public class CrearPeliculaDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Genero { get; set; }

        public string? Sinopsis { get; set; }

        [Required]
        public int Duracion { get; set; }

        public string? ImagenUrl { get; set; }
    }
}
