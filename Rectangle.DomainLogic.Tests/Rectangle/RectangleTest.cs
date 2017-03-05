using NUnit.Framework;
using Rectangle.DomainLogic.Tests.Coordinate;

namespace Rectangle.DomainLogic.Tests.Rectangle
{
    [TestFixture]
    internal class RectangleTest
    {
        private int Height;
        private int Width;

        [SetUp]
        public void Setup()
        {
            this.Height = 4;
            this.Width = 9;
        }

        [Test]
        public void GivenNothing_WhenConstructingARectangle_Then_BottomLeftCoordinateMustEqualTheOneThatWasInput()
        {
            var rectangle = new Domain.Rectangle(1, CoordinateStubs.CoordinateStub, Height, Width);

            Assert.AreEqual(rectangle.BottomLeftCoordinate.X, CoordinateStubs.CoordinateStub.X); 
            Assert.AreEqual(rectangle.BottomLeftCoordinate.Y, CoordinateStubs.CoordinateStub.Y);
        }

        [Test]
        public void Given_Nothing_WhenConstructingARectangle_Then_BottomRightCoordinateMustHaveWidthAddedToBottomLeftXCoordinate()
        {
            var rectangle = new Domain.Rectangle(1, CoordinateStubs.CoordinateStub, Height, Width);

            Assert.AreEqual(rectangle.BottomRightCoordinate.X, CoordinateStubs.CoordinateStub.X + Width);
            Assert.AreEqual(rectangle.BottomRightCoordinate.Y, CoordinateStubs.CoordinateStub.Y);
        }

        [Test]
        public void Given_Nothing_WhenConstructingARectangle_Then_TopLeftCoordinateMustHaveHeightAddedToBottomLeftYCoordinate()
        {
            var rectangle = new Domain.Rectangle(1, CoordinateStubs.CoordinateStub, Height, Width);

            Assert.AreEqual(rectangle.TopLeftCoordinate.X, CoordinateStubs.CoordinateStub.X);
            Assert.AreEqual(rectangle.TopLeftCoordinate.Y, CoordinateStubs.CoordinateStub.Y + Height);
        }

        [Test]
        public void Given_Nothing_WhenConstructingARectangle_Then_TopRightCoordinateMustHaveWidthAndHeightAddedToBottomLeftXAndYCoordinateRespectively()
        {
            var rectangle = new Domain.Rectangle(1, CoordinateStubs.CoordinateStub, Height, Width);

            Assert.AreEqual(rectangle.TopRightCoordinate.X, CoordinateStubs.CoordinateStub.X + Width);
            Assert.AreEqual(rectangle.TopRightCoordinate.Y, CoordinateStubs.CoordinateStub.Y + Height);
        }
    }
}
