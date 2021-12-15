using MKT.Business;
using System.Web.Mvc;

namespace MKT.Site.Controllers
{
    public class OrderDetailController : Controller
    {
        public ActionResult ShowOrderDetail(int id)
        {
            var bizOrderDetail = new BizOrderDetail();
            var model = bizOrderDetail.TraerTodos(id);
            return View(model);
        }
    }
}