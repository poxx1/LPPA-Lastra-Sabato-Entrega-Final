using MKT.Business;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using MKT.Entities.Models;

namespace MKT.Site.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [Authorize]

        public ActionResult UserProfile()
        {
            BizUsuario bizUsuario = new BizUsuario();
            User usuario = new User();
            var CUser = (ClaimsIdentity)User.Identity;
            var VMail = CUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            string eMail = VMail.Value;
            usuario = bizUsuario.TraerPorEmail(eMail);

            //ViewBag.Usuario = usuario;

            usuario.Direccion.ToList();

            return View(usuario);
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }
        //[Authorize]
        [HttpGet]
        public ActionResult UserRegisterAddress()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]
        public ActionResult UserRegisterAddress(Address Model)
        {
            BizDireccion bizDireccion = new BizDireccion();
            BizUsuario bizUsuario = new BizUsuario();
            User usuario = bizUsuario.TraerPorEmail(User.Identity.Name);
            Model.UserId = usuario.Id;

            bizDireccion.Agregar(Model);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserRegister(User Model)
        {
            /* var bizUsuario = new BizUsuario();
            bizUsuario.Agregar(Model);
            return RedirectToAction("Index", "Home");*/

            try
            {
                if (!ModelState.IsValid)

                {
                    return View();
                }
                else
                {
                    var bizUsuario = new BizUsuario();
                    var oUser = new MKT.Entities.Models.User();
                    oUser = bizUsuario.TraerPorEmail(Model.Email);
                    if (oUser != null)
                    {
                        ViewBag.Mensaje = "eMail Ya Registrado! ";

                        return View();
                    }
                    else
                    {

                        bizUsuario.Agregar(Model);

                        return RedirectToAction("Index", "Home");
                    }


                }


            }

            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            BizUsuario bizUsuario = new BizUsuario();
            User usuario = new User();
            var CUser = (ClaimsIdentity)User.Identity;
            var VMail = CUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            string eMail = VMail.Value;
            usuario = bizUsuario.TraerPorEmail(eMail);

            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditProfile(User model)
        {
            var bizUsuario = new BizUsuario();
            bizUsuario.Actualizar(model);

            return RedirectToAction("UserProfile");
        }
    }
}
