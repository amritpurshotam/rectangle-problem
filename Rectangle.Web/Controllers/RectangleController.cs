using System.IO;
using System.Text;
using System.Web.Mvc;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generate(GenerateRectangleInput model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var grid = gridService.InitialiseWithRectanglesOfRandomSize(model.NumberOfRectangles);
                return File(Encoding.UTF8.GetBytes(grid.ToStringUsingDimensionsOfRectangles()), "text/plain", "rectangle-dimensions.txt");
            }
            catch (LogicException ex)
            {
                ModelState.AddLogicErrors(ex);
                return View(model);
            }
        }

        public const string UploadActionName = "Upload";
        [HttpGet]
        public ActionResult Upload()
        {
            var model = new UploadInput();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(UploadInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            try
            {
                using (var streamReader = new StreamReader(input.RectanglesFile.InputStream))
                {
                    var rectanglesString = streamReader.ReadToEnd();
                    var grid = gridService.InitialiseGridFromString(rectanglesString);

                    var model = new SolutionRectanglesDisplay(grid, grid.GetMinimumVerticallyStackedRectangles());
                    return View("Solution", model);
                }
            }
            catch (LogicException ex)
            {
                ModelState.AddLogicErrors(ex);
                return View(input);
            }
        }

        public const string DownloadSolutionActionName = "DownloadSolution";
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DownloadSolution(GridInput model)
        {
            var grid = model.ToDomain();
            return File(Encoding.UTF8.GetBytes(grid.ToStringUsingCoordinatesOfRectangles()), "text/plain", "solution-rectangle-coordinates.txt");
        }
    }
}