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

        [Test]
        public void Given_AGrid_WhenConvertingToStringWithDimensions_ThenStringIsFormattedInAHumanReadableFormat()
        {
            var grid = GridStubs.GridStub;

            var gridString = grid.ToStringUsingDimensionsOfRectangles();

            Assert.AreEqual("Rectangle Dimensions\r\nHeight:\t4\r\nWidth:\t2\r\n\r\n\r\nRectangle Dimensions\r\nHeight:\t2\r\nWidth:\t1\r\n\r\n\r\n", gridString);
        }

        [Test]
        public void Given_AGrid_WhenConvertingToStringWithCoordinates_ThenStringIsFormattedInAHumanReadableFormat()
        {
            var grid = GridStubs.GridStub;

            var gridString = grid.ToStringUsingCoordinatesOfRectangles();

            Assert.AreEqual("Rectangle Coordinates\r\nBottomLeft:\t(0,0)\r\nTopLeft:\t(0,4)\r\nTopRight:\t(2,4)\r\nBottomRight:\t(2,0)\r\n\r\n\r\nRectangle Coordinates\r\nBottomLeft:\t(2,0)\r\nTopLeft:\t(2,2)\r\nTopRight:\t(3,2)\r\nBottomRight:\t(3,0)\r\n\r\n\r\n", gridString);
        }

        [Test]
        public void Give_AGrid_WhenCalculatingMinimumVerticallyStackedRectangles_ThenNumberOfRectanglesIsCorrect()
        {
            var grid = GridStubs.GridStub2;

            var solutionGrid = grid.GetMinimumVerticallyStackedRectangles();

            Assert.AreEqual(3, solutionGrid.RectangleList.Count);
        }

        [Test]
        public void Give_AGrid_WhenCalculatingMinimumVerticallyStackedRectangles_RectangleDimensionsAreCorrect()
        {
            var grid = GridStubs.GridStub2;

            var solutionGrid = grid.GetMinimumVerticallyStackedRectangles();

            Assert.AreEqual(0, solutionGrid.RectangleList[0].BottomLeftCoordinate.X);
            Assert.AreEqual(0, solutionGrid.RectangleList[0].BottomLeftCoordinate.Y);
            Assert.AreEqual(2, solutionGrid.RectangleList[0].Height);
            Assert.AreEqual(7, solutionGrid.RectangleList[0].Width);

            Assert.AreEqual(0, solutionGrid.RectangleList[1].BottomLeftCoordinate.X);
            Assert.AreEqual(2, solutionGrid.RectangleList[1].BottomLeftCoordinate.Y);
            Assert.AreEqual(2, solutionGrid.RectangleList[1].Height);
            Assert.AreEqual(2, solutionGrid.RectangleList[1].Width);

            Assert.AreEqual(3, solutionGrid.RectangleList[2].BottomLeftCoordinate.X);
            Assert.AreEqual(2, solutionGrid.RectangleList[2].BottomLeftCoordinate.Y);
            Assert.AreEqual(1, solutionGrid.RectangleList[2].Height);
            Assert.AreEqual(4, solutionGrid.RectangleList[2].Width);
        }
    }
}