using System.Text;
using System.Web.Mvc;
using LIGate.Domain.Errors;
using Rectangle.Domain.Errors;
using Rectangle.Domain.Exceptions;
using Rectangle.DomainLogic.Services.Interfaces;
using RectangleProblem.Extensions;
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
            var model = new GenerateRectangleInput();
            return View(model);
        }

        public const string DownloadActionName = "Download";
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Download(GenerateRectangleInput model)
        {
            if (!ModelState.IsValid)
            {
                return View(GenerateActionName, model);
            }

            try
            {
                var grid = gridService.InitialiseWithRectanglesOfRandomSize(model.NumberOfRectangles);
                return File(Encoding.UTF8.GetBytes(grid.ToStringUsingDimensionsOfRectangles()), "text/plain", "rectangle-dimensions.txt");
            }
            catch (LogicException ex)
            {
                ModelState.AddLogicErrors(ex);
                return View(GenerateActionName, model);
            }
        }
	}
}