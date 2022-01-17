using DatosAcceso.Models;
using DTO_S;

namespace ApiNexos.WebAPI.Mappings
{
    public static partial class MapperAutor
    {
        public static AutorDTO ToDTO(this TblAutor model)  // Convierte de ModelContext a DTO
        {
            return new AutorDTO()
            {
                IdAutor = model.IdAutor,
                Nombrecompleto = model.Nombrecompleto,
                Fechanacimiento = model.Fechanacimiento,
                Ciudadprocedencia = model.Ciudadprocedencia,
                Correo = model.Correo,
               
            };
        }
    }

    public static partial class MapperAutor
    {
        public static TblAutor ToDatabase(this AutorDTO dto)  // Convierte de DTO a ModelContext
        {
            return new TblAutor()
            {
                IdAutor = dto.IdAutor,
                Nombrecompleto = dto.Nombrecompleto,
                Fechanacimiento = dto.Fechanacimiento,
                Ciudadprocedencia = dto.Ciudadprocedencia,
                Correo = dto.Correo,
                
            };
        }
    }
}