using System.Text;
using System.Web.Mvc;
using Rectangle.DomainLogic.Services.Interfaces;
using RectangleProblem.Models.Rectangle;

namespace RectangleProblem.Controllers
{
    public class RectangleController : Controller
    {
        public const string RectangleControllerName = "Rectangle";
        private readonly IGridService gridService;

        public RectangleController(IGridService gridService)
        {
            this.gridService = gridService;
        }

        public const string GenerateActionName = "Generate";
        [HttpGet]
        public ActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Download(GenerateRectangleInput model)
        {
            var grid = gridService.InitialiseWithRectanglesOfRandomSize(model.NumberOfRectangles);
            return File(Encoding.UTF8.GetBytes(grid.ToStringUsingDimensionsOfRectangles()), "text/plain");
        }
	}
}