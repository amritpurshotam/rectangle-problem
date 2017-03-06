using System.Collections.Generic;
using Rectangle.Domain;

namespace RectangleProblem.Models.Rectangle
{
    public class GridInput
    {
        public IList<RectangleInput> RectangleInputList { get; set; }

        public Grid ToDomain()
        {
            var grid = new Grid();
            foreach (var rectangleInput in RectangleInputList)
            {
                var rectangle = new global::Rectangle.Domain.Rectangle(rectangleInput.RectangleId,
                    new Coordinate(rectangleInput.X, rectangleInput.Y), rectangleInput.Height, rectangleInput.Width);
                grid.AddRectangle(rectangle);
            }
            return grid;
        }
    }
}