using System;
using System.Collections.Generic;

namespace DatosAcceso.Models
{
    public partial class TblAutor
    {
        public TblAutor()
        {
            TblLibros = new HashSet<TblLibro>();
        }

        public decimal IdAutor { get; set; }
        public string Nombrecompleto { get; set; } = null!;
        public DateTime Fechanacimiento { get; set; }
        public string Ciudadprocedencia { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public virtual ICollection<TblLibro> TblLibros { get; set; }
    }
}
