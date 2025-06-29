using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CineCartelera.API.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string? Sinopsis { get; set; }
        public int Duracion { get; set; }
        public string? ImagenURl {  get; set; }
        public ICollection<Funcion> Funciones { get; set; }

    }
}
