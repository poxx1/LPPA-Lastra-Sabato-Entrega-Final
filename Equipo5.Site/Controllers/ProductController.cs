using System;
using System.Web;
using System.Web.Mvc;
using MKT.Business;
using MKT.Entities.Models;

namespace MKT.Site.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var bizCategory = new BizCategory();
            ViewBag.ListadoCategorias = new SelectList(bizCategory.TraerTodos(), "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase imagenProducto)
        {
            if (!ModelState.IsValid)
            {
                var bizCategory = new BizCategory();
                ViewBag.ListadoCategorias = new SelectList(bizCategory.TraerTodos(), "Id", "Nombre");
                return View();
            }

            try
            {
                var biz = new BizProducto();
                model.FotoProducto = new byte[imagenProducto.ContentLength];
                imagenProducto.InputStream.Read(model.FotoProducto, 0, imagenProducto.ContentLength);
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
            var bizProducto = new BizProducto();
            ViewBag.ListadoCategorias = new SelectList(bizCategory.TraerTodos(), "Id", "Nombre");
            var model = bizProducto.TraerPorId(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product producto, HttpPostedFileBase imagenProducto)
        {
            var bizProducto = new BizProducto();

            if (imagenProducto == null)
            {
                producto.FotoProducto = bizProducto.TraerPorId(producto.Id).FotoProducto;
            }
            else
            {
                producto.FotoProducto = new byte[imagenProducto.ContentLength];
                imagenProducto.InputStream.Read(producto.FotoProducto, 0, imagenProducto.ContentLength);
            }

            bizProducto.Actualizar(producto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Product model)
        {
            var bizProducto = new BizProducto();
            bizProducto.Eliminar(model);
            return RedirectToAction("Index");
        }
    }
}