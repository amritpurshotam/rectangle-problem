namespace Domain
{
    public class Rectangle
    {
        public Rectangle(decimal length, decimal width)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get; private set; }
        public decimal Width { get; private set; }
    }
}
