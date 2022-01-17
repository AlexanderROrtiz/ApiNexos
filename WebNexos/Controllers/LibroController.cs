using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebNexos.Entitys;
using WebNexos.Models;

namespace WebNexos.Controllers
{
    public class LibroController : Controller
    {
        LibroModel model;
        public LibroController()
        {
            this.model = new LibroModel();
        }
        [AsyncTimeout(1000)]
        public async Task<ActionResult> Index()
        {
            List<LibroEntity> cList = await model.GetLibro();
            return View(cList);
        }
        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            LibroEntity a = await model.GetLibroByID(id);
            return View(a);
        }

        // GET: /Create
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: /Create
        [HttpPost]
        public async Task<ActionResult> Create(LibroEntity c)
        {
            try
            {
                await model.AddLibro(c);
                
                return RedirectToAction("Index");
            }
            catch
            {
                //ViewBag.Message = "No es posible registrar el libro, se alcanzó el máximo permitido.";
                return View();
            }
        }
        // GET: /Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            LibroEntity c = await model.GetLibroByID(id);
            return View(c);
        }
        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(LibroEntity c)
        {
            try
            {
                await model.EditLibro(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await model.DeleteLibro(id);
            return RedirectToAction("Index");
        }

    }
}