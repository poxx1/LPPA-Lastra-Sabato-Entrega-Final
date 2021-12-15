using MKT.Business;
using System.Web.Mvc;

namespace MKT.Site.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var bizOrder = new BizOrder();
            var model = bizOrder.TraerTodos();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return RedirectToAction("ShowOrderDetail", "OrderDetail", new {id = id});
        }
    }
}