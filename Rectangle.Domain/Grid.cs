using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Domain
{
    public class Grid
    {
        public Grid()
        {
            RectangleList = new List<Rectangle>();
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
    }
}