using Core.Models;
using ApiTravelLib.Dtos;
using System.Collections.Generic;

namespace ApiTravelLib.Dtos
{
    public class LibroDto
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_paginas { get; set; }
        public int EditorialId { get; set; }
        public EditorialDto Editorial { get; set; }
        public ICollection<Autor> Autor { get; set; }
    }
}
