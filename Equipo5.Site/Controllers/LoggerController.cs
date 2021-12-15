using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;


namespace Equipo5.Site.Controllers
{
    public class LoggerController : Controller
    {
        // GET: Logger
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase log)
        {
            //var raw = Request.Form["xmlLog"];
            var date = "log_" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Day.ToString("d2");

            var sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/LogXML/") + date + @"\" + log.FileName);
            var file = sr.ReadToEnd();

            ViewData["GetStringResult"] = GetString(file);

            return View();

        }

        private string GetString(string file)
        {
            return file;
        }
    }
}
