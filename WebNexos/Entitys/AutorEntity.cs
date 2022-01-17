using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNexos.Entitys
{
    public class AutorEntity
    {
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El Nombre Completo es obligatorio")]
        public string Nombrecompleto { get; set; }
        [Required(ErrorMessage = "La Fecha Nacimiento es obligatoria Formato dd/mm/aaaa")]
        public DateTime Fechanacimiento { get; set; }
        [Required(ErrorMessage = "La Ciudad de Procedencia es obligatoria")]
        public string Ciudadprocedencia { get; set; }
        [Required(ErrorMessage = "El Correo es obligatorio")]
        public string Correo { get; set; } 
    }
}