using System;
using System.Text.RegularExpressions;
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
            AssertNumberOfRectanglesInRange(numberOfRectangles);

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

        public Grid InitialiseGridFromString(string rectanglesString)
        {
            var grid = new Grid();

            var heightWidthRegex = new Regex(@"Height:\t(\d+)[\n\r]+Width:\t(\d+)", RegexOptions.Compiled);
            var heightRegex = new Regex(@"Height:\t(\d+)", RegexOptions.Compiled);
            var widthRegex = new Regex(@"Width:\t(\d+)", RegexOptions.Compiled);
            var digitRegex = new Regex(@"\d+", RegexOptions.Compiled);

            var matches = heightWidthRegex.Matches(rectanglesString);
            AssertNumberOfRectanglesInRange(matches.Count);

            foreach (Match match in matches)
            {
                var heightMatch = heightRegex.Match(match.Value);
                var widthMatch = widthRegex.Match(match.Value);

                var height = int.Parse(digitRegex.Match(heightMatch.Value).Value);
                var width = int.Parse(digitRegex.Match(widthMatch.Value).Value);

                grid.AddRectangle(new Domain.Rectangle(grid.GetNextBottomLeftCoordinate(), height, width));
            }

            return grid;
        }

        private static void AssertNumberOfRectanglesInRange(int numberOfRectangles)
        {
            if (numberOfRectangles < Constants.MinRectangles)
            {
                throw new OutOfRangeError(string.Format("A minimum of {0} rectangles are required.", Constants.MinRectangles)).AsException();
            }

            if (numberOfRectangles > Constants.MaxRectangles)
            {
                throw new OutOfRangeError(string.Format("A maximum of {0} rectangles are required.", Constants.MaxRectangles)).AsException();
            }
        }
    }
}