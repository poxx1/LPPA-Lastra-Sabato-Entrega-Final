using System;
using System.Web.Mvc;
using MKT.Business;
using MKT.Entities.Models;

namespace MKT.Site.Controllers
{

    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var bizCategory = new BizCategory();
            var model = bizCategory.TraerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var biz = new BizCategory();
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
            var bizCategory = new BizCategory();
            var model = bizCategory.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Category categoriaProducto)
        {
            var bizCategory = new BizCategory();
            bizCategory.Actualizar(categoriaProducto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bizCategory = new BizCategory();
            var model = bizCategory.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Category model)
        {
            var bizCategory = new BizCategory();
            bizCategory.Eliminar(model);
            return RedirectToAction("Index");
        }

    }
}
