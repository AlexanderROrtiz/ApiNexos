using DatosAcceso.Models;
using DTO_S;

namespace ApiNexos.WebAPI.Mappings
{
    public static partial class Mapper
    {
        public static LibroDTO ToDTO(this TblLibro model)  // Convierte de ModelContext a DTO
        {
            return new LibroDTO()
            {
                IdLibro = model.IdLibro,
                Titulo = model.Titulo,
                Anio = model.Anio,
                Genero = model.Genero,
                Numeropaginas = model.Numeropaginas,
                IdAutor = model.IdAutor
               
            };
        }
    }

    public static partial class Mapper
    {
        public static TblLibro ToDatabase(this LibroDTO dto)  // Convierte de DTO a ModelContext
        {
            return new TblLibro()
            {
                IdLibro = dto.IdLibro,
                Titulo = dto.Titulo,
                Anio = dto.Anio,
                Genero = dto.Genero,
                Numeropaginas = dto.Numeropaginas,
                IdAutor = dto.IdAutor
                
            };
        }
    }
}