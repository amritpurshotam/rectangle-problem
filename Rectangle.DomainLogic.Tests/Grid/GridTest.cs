using NUnit.Framework;
using Rectangle.DomainLogic.Tests.Rectangle;

namespace Rectangle.DomainLogic.Tests.Grid
{
    [TestFixture]
    internal class GridTest
    {
        [Test]
        public void Given_AGrid_When_AddingARectangle_Then_RectangleListMustHaveOneMoreRectangle()
        {
            var grid = new Domain.Grid();

            grid.AddRectangle(RectangleStubs.RectangleStub);

            Assert.AreEqual(1, grid.RectangleList.Count);
        }

        [Test]
        public void Given_AGrid_When_GettingNextBottomLeftCoordinateAndRectangleListEmpty_Then_UseMinimumCoordinatesOfZeroZero()
        {
            var grid = new Domain.Grid();

            var coordinate = grid.GetNextBottomLeftCoordinate();
            
            Assert.AreEqual(0, coordinate.X);
            Assert.AreEqual(0, coordinate.Y);
        }

        [Test]
        public void Given_AGrid_WhenGettingNextBottomLeftCoordinateAndThereAreSomeRectangles_Then_UseTheLastBottomRightCoordinate()
        {
            var grid = new Domain.Grid();
            grid.AddRectangle(RectangleStubs.RectangleStub);

            var coordinate = grid.GetNextBottomLeftCoordinate();

            Assert.AreEqual(RectangleStubs.RectangleStub.BottomRightCoordinate.X, coordinate.X);
            Assert.AreEqual(RectangleStubs.RectangleStub.BottomRightCoordinate.Y, coordinate.Y);
        }
    }
}