using System.Web.Mvc;

namespace RectangleProblem.Controllers
{
    public class HomeController : Controller
    {
        public const string HomeControllerName = "Home";

        public const string IndexActionName = "Index";
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}