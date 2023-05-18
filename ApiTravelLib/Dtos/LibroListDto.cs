namespace ApiTravelLib.Dtos
{
    public class LibroListDto
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_paginas { get; set; }
        public int EditorialId { get; set; }
        public EditorialDto Editorial { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidosAutor { get; set; }
    }
}
