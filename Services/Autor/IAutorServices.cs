using DatosAcceso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNexos.Services.Autor
{
    public interface IAutorServices
    {
    
            //Se trabaja metodos asincronos y utilizar la respuesta estandar
            Task<RespuestaService<List<TblAutor>>> Listar();

            Task<RespuestaService<TblAutor>> GetById(int id);

            Task<RespuestaService<TblAutor>> Guardar(TblAutor c);

            Task<RespuestaService<TblAutor>> Actualizar(TblAutor c);

            Task<RespuestaService<bool>> Eliminar(int id);
        
    }
}
