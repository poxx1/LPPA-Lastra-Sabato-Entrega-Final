using MKT.Business;
using System.Linq;
using System.Web.Mvc;

namespace MKT.Site.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerTodos().Take(4);

            return View(model);
        }
    }
}