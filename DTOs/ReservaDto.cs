namespace CineCartelera.API.DTOs
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public string NumeroTicket { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string Genero { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public DateTime FechaReserva { get; set; }

        public int FuncionId { get; set; }
        public string PeliculaTitulo { get; set; }
        public string SalaNombre { get; set; }
        public DateTime HoraInicio { get; set; }
    }
}
