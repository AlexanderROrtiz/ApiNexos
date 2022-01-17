using System;
using System.Collections.Generic;

namespace DatosAcceso.Models
{
    public partial class TblLibro
    {
        public decimal IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Anio { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public decimal Numeropaginas { get; set; }
        public decimal? IdAutor { get; set; }

        public virtual TblAutor? IdAutorNavigation { get; set; }
    }
}
