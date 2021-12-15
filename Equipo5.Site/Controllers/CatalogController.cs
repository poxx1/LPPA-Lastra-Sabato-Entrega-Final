using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MKT.Business;

namespace MKT.Site.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        [AllowAnonymous]
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerTodos();

            return View(model);
        }
    }
}