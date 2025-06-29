
using System.ComponentModel.DataAnnotations;

namespace CineCartelera.API.Models

{
    public class Sala
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public ICollection<Funcion> Funciones { get; set; }
    }
}
