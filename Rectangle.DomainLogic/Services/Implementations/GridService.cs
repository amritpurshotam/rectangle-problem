using System;
using Rectangle.Common;
using Rectangle.Domain;
using Rectangle.Domain.Errors;
using Rectangle.DomainLogic.Services.Interfaces;

namespace Rectangle.DomainLogic.Services.Implementations
{
    public class GridService : IGridService
    {
        public GridService()
        {
        }

        public Grid InitialiseWithRectanglesOfRandomSize(byte numberOfRectangles)
        {
            if (numberOfRectangles < Constants.MinRectangles)
            {
                throw new OutOfRangeError(string.Format("A minimum of {0} rectangles are required.", Constants.MinRectangles)).AsException();
            }

            if (numberOfRectangles > Constants.MaxRectangles)
            {
                throw new OutOfRangeError(string.Format("A maximum of {0} rectangles are required.", Constants.MaxRectangles)).AsException();
            }

            var random = new Random();

            var grid = new Grid();
            for (var i = 0; i < numberOfRectangles; i++)
            {
                var height = random.Next(Constants.MinRectangleLength, Constants.MaxRectangleLength);
                var width = random.Next(Constants.MinRectangleLength, Constants.MaxRectangleLength);

                var bottomLeftCoordinate = grid.GetNextBottomLeftCoordinate();
                var rectangle = new Domain.Rectangle(bottomLeftCoordinate, height, width);
                
                grid.AddRectangle(rectangle);
            }

            return grid;
        } 
    }
}