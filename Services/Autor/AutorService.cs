using DatosAcceso.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNexos.Services.Autor
{
    //implementación de la interfaz
    public class AutorService : IAutorServices
    {
        private ModelContext _context;

        public AutorService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<TblAutor>> Actualizar(TblAutor l)
        {
            var res = new RespuestaService<TblAutor>();
            var Autor = await _context.TblAutors.FirstOrDefaultAsync(x => x.IdAutor == l.IdAutor);

            if (Autor == null)
                res.AgregarBadRequest("Id recibido no registrado");
            else
            {
                Autor.Nombrecompleto = l.Nombrecompleto;
                Autor.Fechanacimiento = l.Fechanacimiento;
                Autor.Ciudadprocedencia = l.Ciudadprocedencia;
                Autor.Correo = l.Correo;

                try
                {
                    _context.TblAutors.Update(Autor);
                    await _context.SaveChangesAsync();

                    res.Objeto = Autor;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<TblAutor>> GetById(int id)
        {
            var res = new RespuestaService<TblAutor>();
            var Autor = await _context.TblAutors.FirstOrDefaultAsync(x => x.IdAutor == id);

            if (Autor == null)
                res.AgregarBadRequest("Id recibido no registrado");
            else
                res.Objeto = Autor;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var Autor = await _context.TblAutors.FirstOrDefaultAsync(x => x.IdAutor == id);

            if (Autor == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.TblAutors.Remove(Autor);
                    await _context.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<TblAutor>> Guardar(TblAutor c)
        {
            var res = new RespuestaService<TblAutor>();

            try
            {
                await _context.TblAutors.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdAutor = await _context.TblAutors.MaxAsync(u => u.IdAutor);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<TblAutor>>> Listar()
        {
            var res = new RespuestaService<List<TblAutor>>();
            var lista = await _context.TblAutors.ToListAsync();
            
            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
