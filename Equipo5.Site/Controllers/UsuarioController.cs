using System;
using System.Web.Mvc;
using MKT.Business;
using MKT.Entities.Models;

namespace MKT.Site.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var bizUsuario = new BizUsuario();
            var model = bizUsuario.TraerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var bizRol = new BizRol();
            ViewBag.ListadoRoles = new SelectList(bizRol.TraerTodos(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(User usuario)
        {
            if (!ModelState.IsValid)
            {
                var bizRol = new BizRol();
                ViewBag.ListadoRoles = new SelectList(bizRol.TraerTodos(), "Id", "Nombre");
                ModelState.AddModelError("FechaNacimiento", "Fecha Nacimiento Invalida");
                return View(usuario);
            }

            try
            {
                var bizUsuario = new BizUsuario();
                //Agregar el generador de pass y Save usuario
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(usuario);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bizRol = new BizRol();
            ViewBag.ListadoRoles = new SelectList(bizRol.TraerTodos(), "Id", "Nombre");
            var bizUsuario = new BizUsuario();
            var model = bizUsuario.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User usuario)
        {
            var bizUsuario = new BizUsuario();
            var oldUsuario = bizUsuario.TraerPorId(usuario.Id);
            usuario.Email_ = oldUsuario.Email;
            usuario.Email = oldUsuario.Email;
            usuario.Password_ = oldUsuario.Password;
            usuario.Password = oldUsuario.Password;

            bizUsuario.Actualizar(usuario);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bizUsuario = new BizUsuario();
            var model = bizUsuario.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(User usuario)
        {
            var bizUsuario = new BizUsuario();
            var model = bizUsuario.TraerPorId(usuario.Id);

            bizUsuario.Eliminar(model.Id);

            return RedirectToAction("Index");
        }

    }
}