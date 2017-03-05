namespace Rectangle.Domain
{
    internal class CoordinateRange
    {
        public CoordinateRange(int minY, int minX, int maxX)
        {
            this.MinY = minY;
            this.MinX = minX;
            this.MaxX = maxX;
        }

        public int MinY { get; private set; }
        public int MinX { get; private set; }
        public int MaxX { get; private set; }
    }
}