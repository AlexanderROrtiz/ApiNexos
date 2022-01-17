using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_S
{
    public class AutorDTO
    {
        public decimal IdAutor { get; set; }
        public string Nombrecompleto { get; set; } = null!;
        public DateTime Fechanacimiento { get; set; }
        public string Ciudadprocedencia { get; set; } = null!;
        public string Correo { get; set; } = null!;
    }
}
