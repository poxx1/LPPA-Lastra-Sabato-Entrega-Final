using MKT.Business;
using System.Web.Mvc;

namespace MKT.Site.Controllers
{
    public class CartItemController : Controller
    {
        public ActionResult Index(int id)
        {
            var bizCarrito = new BizCarrito();
            var model = bizCarrito.TraerCartItems(id);
            return View(model);
        }

        public ActionResult IndexAdmin(int id)
        {
            var bizCarrito = new BizCarrito();
            var model = bizCarrito.TraerCartItems(id);
            return View(model);
        }
    }
}