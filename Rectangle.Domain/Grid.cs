using System.Collections.Generic;

namespace Rectangle.Domain
{
    public class Grid
    {
        public Grid()
        {
            RectangleList = new List<Rectangle>();
        }

        public IList<Rectangle> RectangleList { get; private set; }
    }
}
