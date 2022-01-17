using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNexos.Entitys
{
    public class LibroEntity
    {
        public int IdLibro { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El Año es obligatorio")]
        public string Anio { get; set; }
        [Required(ErrorMessage = "El Genero del libro es obligatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El Numero de paginas obligatorio")]
        public int Numeropaginas { get; set; }
        public int? IdAutor { get; set; }
    }
}