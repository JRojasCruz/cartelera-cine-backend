namespace CineCartelera.API.Models
{
    public class Funcion
    {
        public int Id { get; set; }
        public int PeliculaId {  get; set; }
        public int SalaId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin {  get; set; }
        public int Capacidad { get; set; }
        public Pelicula Pelicula { get; set; }
        public Sala Sala { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

    }
}
