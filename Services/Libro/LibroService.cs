using DatosAcceso.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNexos.Services.Libro
{
    //implementación de la interfaz
    public class LibroService : ILibroService
    {
        private ModelContext _context;

        public LibroService(ModelContext context)
        {
            _context = context;
        }
        
        public async Task<RespuestaService<TblLibro>> Actualizar(TblLibro l)
        {
            var res = new RespuestaService<TblLibro>();
            var Libro = await _context.TblLibros.FirstOrDefaultAsync(x => x.IdLibro == l.IdLibro);

            if (Libro == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                Libro.Titulo = l.Titulo;
                Libro.Anio = l.Anio;
                Libro.Genero = l.Genero;
                Libro.Numeropaginas = l.Numeropaginas;

                try
                {
                    _context.TblLibros.Update(Libro);
                    await _context.SaveChangesAsync();

                    res.Objeto = Libro;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<TblLibro>> GetById(int id)
        {
            var res = new RespuestaService<TblLibro>();
            var Libro = await _context.TblLibros.FirstOrDefaultAsync(x => x.IdLibro == id);

            if (Libro == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = Libro;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var Libro = await _context.TblLibros.FirstOrDefaultAsync(x => x.IdLibro == id);

            if (Libro == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.TblLibros.Remove(Libro);
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

        public async Task<RespuestaService<TblLibro>> Guardar(TblLibro c)
        {
            var res = new RespuestaService<TblLibro>();

            try
            {
                await _context.TblLibros.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdLibro = await _context.TblLibros.MaxAsync(u => u.IdLibro);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<TblLibro>>> Listar()
        {
            var res = new RespuestaService<List<TblLibro>>();
            var lista = await _context.TblLibros.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
