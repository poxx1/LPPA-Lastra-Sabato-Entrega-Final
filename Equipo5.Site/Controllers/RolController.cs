using System;
using System.Web.Mvc;
using MKT.Business;
using MKT.Entities.Models;

namespace MKT.Site.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            var bizRol = new BizRol();
            var model = bizRol.TraerTodos();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rol model)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var biz = new BizRol();
                biz.Agregar(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                /// Que pasa con el error -> Bitacoras
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bizRol = new BizRol();
            var model = bizRol.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Rol rol)
        {
            var bizRol = new BizRol();
            bizRol.Actualizar(rol);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bizRol = new BizRol();
            bizRol.Eliminar(id);

            return Json(new { status = "Success" });
        }
    }
}