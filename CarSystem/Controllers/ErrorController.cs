using System.Net;
using System.Web.Mvc;

namespace CarSystem.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return View("Error");
        }

        public ActionResult BadRequest()
        {
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            ViewBag.Name = "Error - Bad Request";
            ViewBag.Description = "The request cannot be fulfilled due to bad syntax. If you believe that this is a mistake, please contact the system administrator.";
            return View("Error");
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = (int) HttpStatusCode.Forbidden;
            ViewBag.Name = "Error - Forbidden";
            ViewBag.Description = "Forbidden: You don't have permission to access this page or resource. If you believe that this is a mistake, please contact the system administrator.";
            return View("Error");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = (int) HttpStatusCode.NotFound;
            ViewBag.Name = "Error - Not Found";
            ViewBag.Description = "We are sorry, the page or resource you requested cannot be found. The URL may be misspelled or the page you're looking for is no longer available.. If you believe that this is a mistake, please contact the system administrator.";
            return View("Error");
        }

        public ActionResult URLTooLong()
        {
            Response.StatusCode = (int) HttpStatusCode.RequestUriTooLong;
            ViewBag.Name = "Error - URL Too Long";
            ViewBag.Description = "The requested URL is too large to process. That’s all we know. If you believe that this is a mistake, please contact the system administrator.";
            return View("Error");
        }

        public ActionResult ThrowURLTooLong()
        {
            return URLTooLong();
        }
    }
}