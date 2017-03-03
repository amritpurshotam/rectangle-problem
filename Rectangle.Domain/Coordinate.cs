namespace Domain
{
    public class Coordinate
    {
        public Coordinate(decimal x, decimal y)
        {
            this.X = x;
            this.Y = y;
        }

        public decimal X { get; private set; }
        public decimal Y { get; private set; }
    }
}
