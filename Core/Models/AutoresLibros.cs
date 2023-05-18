namespace Core.Models
{
    public class AutoresLibros
    {
        public int LibroIsbn { get; set; }
        public Libro Libro { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
