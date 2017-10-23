using System.Web.Mvc;

namespace CarSystem.Controllers
{
    [HandleError]
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            //EmailHelper.SendEmail(); email the administrator to quickly find issues..
            return View("Error");
        }

        public ActionResult BadRequest()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult URLTooLong()
        {
            return View();
        }

        public ActionResult ServiceUnavailable()
        {
            return View();
        }
    }
}