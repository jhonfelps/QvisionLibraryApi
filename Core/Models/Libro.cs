using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Libro
    {
        [Key]
        public int isbn { get; set; }
        public string titulo { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string sinopsis { get; set; }
        public string n_paginas { get; set; }
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }
        public ICollection<Autor> Autores { get; set; } = new HashSet<Autor>();
        public ICollection<AutoresLibros> AutoresLibros { get; set;}
            
    }
}
