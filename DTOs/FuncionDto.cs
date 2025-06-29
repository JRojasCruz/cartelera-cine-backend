namespace CineCartelera.API.DTOs
{
    public class FuncionDto
    {
        public int Id { get; set; }

        public int PeliculaId { get; set; }
        public string PeliculaTitulo { get; set; }

        public int SalaId { get; set; }
        public string SalaNombre { get; set; }

        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public int Capacidad { get; set; }
    }
}
