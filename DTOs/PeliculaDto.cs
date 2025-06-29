namespace CineCartelera.API.DTOs
{
    public class PeliculaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string? Sinopsis { get; set; }
        public int Duracion { get; set; }
        public string? ImagenUrl { get; set; }
        public ICollection<FuncionDto>? Funciones { get; set; } // <-- importante

    }
}
