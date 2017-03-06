using System.Text;
using NUnit.Framework;
using Rectangle.Common;
using Rectangle.Domain.Exceptions;
using Rectangle.DomainLogic.Services.Implementations;
using Rectangle.DomainLogic.Services.Interfaces;

namespace Rectangle.DomainLogic.Tests.Grid
{
    [TestFixture]
    internal class GridServiceTest
    {
        private IGridService gridService;

        [SetUp]
        public void Setup()
        {
            this.gridService = new GridService();
        }

        [Test]
        public void GivenNumberOfRectanglesToGenerate_WhenInitialisingGrid_ThenGridMustHaveTheSpecifiedNumberOfRectangles()
        {
            const byte numberOfRectanglesToGenerate = 5;
            var grid = this.gridService.InitialiseWithRectanglesOfRandomSize(numberOfRectanglesToGenerate);
            Assert.AreEqual(5, grid.RectangleList.Count);
        }

        [Test]
        public void GivenARectangleString_When_InitialisingGrid_ThenGridMustHaveTheRectanglesSpecifiedInTheStringWithCorrectDimensions()
        {
            const string rectanglesString = "Rectangle Dimensions\r\nHeight:\t1\r\nWidth:\t6\r\n\r\n\r\nRectangle Dimensions\r\nHeight:\t1\r\nWidth:\t2\r\n\r\n\r\nRectangle Dimensions\r\nHeight:\t4\r\nWidth:\t9\r\n\r\n\r\n";
            var grid = this.gridService.InitialiseGridFromString(rectanglesString);

            Assert.AreEqual(1, grid.RectangleList[0].Height);
            Assert.AreEqual(6, grid.RectangleList[0].Width);

            Assert.AreEqual(1, grid.RectangleList[1].Height);
            Assert.AreEqual(2, grid.RectangleList[1].Width);

            Assert.AreEqual(4, grid.RectangleList[2].Height);
            Assert.AreEqual(9, grid.RectangleList[2].Width);
        }

        [Test]
        public void GivenARectangleString_When_InitialisingGrid_ThenGridMustHaveTheSameNumberOfRectanglesSpecified()
        {
            const string rectanglesString = "Rectangle Dimensions\r\nHeight:\t1\r\nWidth:\t6\r\n\r\n\r\nRectangle Dimensions\r\nHeight:\t1\r\nWidth:\t2\r\n\r\n\r\nRectangle Dimensions\r\nHeight:\t4\r\nWidth:\t9\r\n\r\n\r\n";
            var grid = this.gridService.InitialiseGridFromString(rectanglesString);

            Assert.AreEqual(3, grid.RectangleList.Count);
        }

        [Test]
        public void GivenAnInvalidRectangleString_When_InitialisingGrid_ThenThrowLogicError()
        {
            const string rectanglesString = "abc123";

            Assert.Throws(Is.TypeOf<LogicException>().And.Message.Contains(string.Format("A minimum of {0} rectangles are required.", Constants.MinRectangles)),
                () => this.gridService.InitialiseGridFromString(rectanglesString));
        }

        [Test]
        public void GivenARectangleStringWithFewerThanTheMinimumRectangles_When_InitialisingGrid_ThenThrowLogicError()
        {
            const string rectanglesString = "Rectangle Dimensions\r\nHeight:\t1\r\nWidth:\t6\r\n\r\n\r\nRectangle Dimensions\r\nHeight:\t1\r\nWidth:\t2\r\n\r\n\r\n";

            Assert.Throws(Is.TypeOf<LogicException>().And.Message.Contains(string.Format("A minimum of {0} rectangles are required.", Constants.MinRectangles)),
                () => this.gridService.InitialiseGridFromString(rectanglesString));
        }

        [Test]
        public void GivenARectangleStringWithMoreThanTheMaximumRectangles_When_InitialisingGrid_ThenThrowLogicError()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Constants.MaxRectangleHeight + 5; i++)
            {
                sb.Append("Rectangle Dimensions\r\nHeight:\t1\r\nWidth:\t6\r\n\r\n\r\n");
            }
            var rectanglesString = sb.ToString();

            Assert.Throws(Is.TypeOf<LogicException>().And.Message.Contains(string.Format("A maximum of {0} rectangles are required.", Constants.MaxRectangles)),
                () => this.gridService.InitialiseGridFromString(rectanglesString));
        }
    }
}
