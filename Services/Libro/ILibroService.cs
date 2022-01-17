using DatosAcceso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNexos.Services.Libro
{
    public interface ILibroService
    {
        //Se trabaja metodos asincronos y utilizar la respuesta estandar
        Task<RespuestaService<List<TblLibro>>> Listar();

        Task<RespuestaService<TblLibro>> GetById(int id);

        Task<RespuestaService<TblLibro>> Guardar(TblLibro c);

        Task<RespuestaService<TblLibro>> Actualizar(TblLibro c);

        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
