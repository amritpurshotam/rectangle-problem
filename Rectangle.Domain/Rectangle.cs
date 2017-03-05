using System.Text;

namespace Rectangle.Domain
{
    public class Rectangle
    {
        public Rectangle(int rectangleId, Coordinate bottomLeftCoordinate, int height, int width)
        {
            this.RectangleId = rectangleId;
            this.BottomLeftCoordinate = bottomLeftCoordinate;
            this.Height = height;
            this.Width = width;
        }

        public int RectangleId { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Coordinate BottomLeftCoordinate { get; private set; }

        public Coordinate BottomRightCoordinate
        {
            get { return new Coordinate(BottomLeftCoordinate.X + this.Width, BottomLeftCoordinate.Y); }
        }

        public Coordinate TopLeftCoordinate
        {
            get { return new Coordinate(BottomLeftCoordinate.X, BottomLeftCoordinate.Y + this.Height); }
        }

        public Coordinate TopRightCoordinate
        {
            get { return new Coordinate(BottomLeftCoordinate.X + this.Width, BottomLeftCoordinate.Y + this.Height); }
        }

        public string ToHumanReadableStringWithDimensions()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Rectangle Dimensions");
            builder.AppendLine("Height:\t" + this.Height);
            builder.AppendLine("Width:\t" + this.Width);
            return builder.ToString();
        }

        public string ToHumanReadableStringWithCoordinates()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Rectangle Coordinates");
            builder.AppendLine("BottomLeft:\t" + this.BottomLeftCoordinate);
            builder.AppendLine("TopLeft:\t" + this.TopLeftCoordinate);
            builder.AppendLine("TopRight:\t" + this.TopRightCoordinate);
            builder.AppendLine("BottomRight:\t" + this.BottomRightCoordinate);
            return builder.ToString();
        }
    }
}