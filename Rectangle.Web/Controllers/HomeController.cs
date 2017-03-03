using System.Web.Mvc;

namespace RectangleProblem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}