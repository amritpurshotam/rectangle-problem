namespace Domain
{
    public class Rectangle
    {
        public Rectangle(Coordinate bottomLeftCoordinate, decimal length, decimal width)
        {
            this.BottomLeftCoordinate = bottomLeftCoordinate;
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get; private set; }
        public decimal Width { get; private set; }

        public Coordinate BottomLeftCoordinate { get; private set; }

        public Coordinate BottomRightCoordinate
        {
            get { return new Coordinate(BottomLeftCoordinate.X + this.Width, BottomLeftCoordinate.Y); }
        }

        public Coordinate TopLeftCoordinate
        {
            get { return new Coordinate(BottomLeftCoordinate.X, BottomLeftCoordinate.Y + this.Length); }
        }

        public Coordinate TopRightCoordinate
        {
            get { return new Coordinate(BottomLeftCoordinate.X + this.Width, BottomLeftCoordinate.Y + this.Length); }
        }
    }
}
