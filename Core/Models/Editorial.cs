using System.Collections.Generic;

namespace Core.Models
{
    public class Editorial
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string sede { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
