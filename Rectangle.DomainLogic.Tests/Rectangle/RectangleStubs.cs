using Rectangle.Domain;

namespace Rectangle.DomainLogic.Tests.Rectangle
{
    internal static class RectangleStubs
    {
        internal static Domain.Rectangle RectangleStub
        {
            get
            {
                return new Domain.Rectangle(new Coordinate(0,0), 3, 5);
            }
        }
    }
}
