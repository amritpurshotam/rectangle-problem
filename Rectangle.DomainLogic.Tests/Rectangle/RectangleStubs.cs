using Rectangle.DomainLogic.Tests.Coordinate;

namespace Rectangle.DomainLogic.Tests.Rectangle
{
    internal static class RectangleStubs
    {
        internal static Domain.Rectangle RectangleStub
        {
            get
            {
                return new Domain.Rectangle(CoordinateStubs.CoordinateStub, 3, 5);
            }
        }
    }
}
