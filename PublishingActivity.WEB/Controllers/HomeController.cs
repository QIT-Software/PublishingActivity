using System;
using System.Web.Mvc;

namespace PublishingActivity.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "admin")]
        public FileResult GetTodayLog()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            string file_path = Server.MapPath($"~/logs/{date}.log");
            string file_type = "application/log";
            string file_name = $"{date}.log";
            return File(file_path, file_type, file_name);
        }
    }
}