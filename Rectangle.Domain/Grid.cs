using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rectangle.Domain
{
    public class Grid
    {
        public Grid()
        {
            this.RectangleList = new List<Rectangle>();
        }

        public IList<Rectangle> RectangleList { get; private set; }

        public void AddRectangle(Rectangle rectangle)
        {
            this.RectangleList.Add(rectangle);
        }

        public Coordinate GetNextBottomLeftCoordinate()
        {
            if (!this.RectangleList.Any())
            {
                return new Coordinate(0, 0);
            }

            return this.RectangleList.Last().BottomRightCoordinate;
        }

        public string ToStringUsingDimensionsOfRectangles()
        {
            var builder = new StringBuilder();
            foreach (var rectangle in this.RectangleList)
            {
                builder.AppendLine(rectangle.ToHumanReadableStringWithDimensions());
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public string ToStringUsingCoordinatesOfRectangles()
        {
            var builder = new StringBuilder();
            foreach (var rectangle in this.RectangleList)
            {
                builder.AppendLine(rectangle.ToHumanReadableStringWithCoordinates());
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}