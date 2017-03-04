namespace Rectangle.Domain
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.X, this.Y);
        }
    }
}