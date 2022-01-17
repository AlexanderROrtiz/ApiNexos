using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_S
{
    public class LibroDTO
    {
        public decimal IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Anio { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public decimal Numeropaginas { get; set; }
        public decimal? IdAutor { get; set; }
    }
}
