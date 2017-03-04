namespace Rectangle.Domain
{
    public class Rectangle
    {
        public Rectangle(Coordinate bottomLeftCoordinate, int height, int width)
        {
            this.BottomLeftCoordinate = bottomLeftCoordinate;
            this.Height = height;
            this.Width = width;
        }

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
    }
}