using NUnit.Framework;
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
            var grid = this.gridService.InitialiseGrid(numberOfRectanglesToGenerate);
            Assert.AreEqual(5, grid.RectangleList.Count);
        }
    }
}
