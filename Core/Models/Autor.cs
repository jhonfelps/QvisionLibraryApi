using System.Collections.Generic;

namespace Core.Models
{
    public class Autor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public ICollection<Libro> Libros { get; set; } = new HashSet<Libro>();
        public ICollection<AutoresLibros> AutoresLibros { get; set; }
    }
}
