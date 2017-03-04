using System.Web.Mvc;

namespace RectangleProblem.Controllers
{
    public class RectangleController : Controller
    {
        public const string RectangleControllerName = "Rectangle";

        public const string GenerateActionName = "Generate";
        [HttpGet]
        public ActionResult Generate()
        {
            return View();
        }
	}
}