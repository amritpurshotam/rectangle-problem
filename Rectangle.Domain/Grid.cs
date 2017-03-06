using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rectangle.Domain
{
    public class Grid
    {
        public Grid()
        {
            this.RectangleList = new List<Rectangle>();
        }

        public IList<Rectangle> RectangleList { get; private set; }

        public void AddRectangle(Rectangle rectangle)
        {
            this.RectangleList.Add(rectangle);
        }

        public Coordinate GetNextBottomLeftCoordinate()
        {
            if (!this.RectangleList.Any())
            {
                return new Coordinate(0, 0);
            }

            return this.RectangleList.Last().BottomRightCoordinate;
        }

        public string ToStringUsingDimensionsOfRectangles()
        {
            var builder = new StringBuilder();
            foreach (var rectangle in this.RectangleList)
            {
                builder.AppendLine(rectangle.ToHumanReadableStringWithDimensions());
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public string ToStringUsingCoordinatesOfRectangles()
        {
            var builder = new StringBuilder();
            foreach (var rectangle in this.RectangleList)
            {
                builder.AppendLine(rectangle.ToHumanReadableStringWithCoordinates());
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public Grid GetMinimumVerticallyStackedRectangles()
        {
            var grid = new Grid();
            var coordinateRangeQueue = new Queue<CoordinateRange>();

            var initialCoordinateRange = new CoordinateRange(0, 0, this.RectangleList.Last().BottomRightCoordinate.X);
            coordinateRangeQueue.Enqueue(initialCoordinateRange);
            
            var rectangleId = 1;
            while (coordinateRangeQueue.Any())
            {
                var coordinateRange = coordinateRangeQueue.Dequeue();
                var nextHeight = this.GetShortestHeightInCoordinateRange(coordinateRange);

                if (this.CanStackMoreRectangles(nextHeight))
                {
                    var shortestRectangles = this.GetRectanglesWithExactHeightInCoordinateRange(nextHeight.Value, coordinateRange);

                    var coordinateRangeToLeftOfFirstRectangle = new CoordinateRange(nextHeight.Value,
                        coordinateRange.MinX, shortestRectangles[0].TopLeftCoordinate.X);
                    coordinateRangeQueue.Enqueue(coordinateRangeToLeftOfFirstRectangle);
                    
                    for (int i = 0; i < shortestRectangles.Length; i++)
                    {
                        if (i < shortestRectangles.Length - 1)
                        {
                            var coordinateRangeBetweenRectangles = new CoordinateRange(nextHeight.Value,
                                shortestRectangles[i].TopRightCoordinate.X,
                                shortestRectangles[i + 1].TopLeftCoordinate.X);
                            coordinateRangeQueue.Enqueue(coordinateRangeBetweenRectangles);
                        }
                        else
                        {
                            if (!IsFarRightRectangle(shortestRectangles[i]))
                            {
                                if (IsRectangleShorterThanTheRectangleToTheRight(shortestRectangles[i]))
                                {
                                    var coordinateRangeToRightOfLastRectangle = new CoordinateRange(nextHeight.Value,
                                        shortestRectangles[i].TopRightCoordinate.X,
                                        this.GetFarRightWidthInRange(coordinateRange));
                                    coordinateRangeQueue.Enqueue(coordinateRangeToRightOfLastRectangle);
                                }
                            }
                        }
                    }

                    var bottomLeftCoordinate = new Coordinate(coordinateRange.MinX, coordinateRange.MinY);
                    var height = nextHeight.Value - coordinateRange.MinY;
                    var width = coordinateRange.MaxX - coordinateRange.MinX;
                    var rectangle = new Rectangle(rectangleId, bottomLeftCoordinate, height, width);
                    rectangleId++;
                    grid.AddRectangle(rectangle);
                }
            }

            return grid;
        }

        private bool IsRectangleShorterThanTheRectangleToTheRight(Rectangle rectangle)
        {
            return rectangle.Height < this.RectangleList.Single(x => x.RectangleId == (rectangle.RectangleId + 1)).Height;
        }

        private bool IsFarRightRectangle(Rectangle rectangle)
        {
            return rectangle.RectangleId == this.RectangleList.Count;
        }

        private int? GetShortestHeightInCoordinateRange(CoordinateRange coordinateRange)
        {
            var rectangles = this.RectangleList
                .Where(
                    x => x.Height > coordinateRange.MinY
                    && x.BottomLeftCoordinate.X >= coordinateRange.MinX
                    && x.BottomRightCoordinate.X <= coordinateRange.MaxX).ToList();

            if (!rectangles.Any())
            {
                return null;
            }

            return rectangles.Min(x => x.Height);
        }

        private Rectangle[] GetRectanglesWithExactHeightInCoordinateRange(int height, CoordinateRange coordinateRange)
        {
            return this.RectangleList
                .Where(
                    x => x.Height == height
                    && x.BottomLeftCoordinate.X >= coordinateRange.MinX
                    && x.BottomRightCoordinate.X <= coordinateRange.MaxX)
                .ToArray();
        }

        private bool CanStackMoreRectangles(int? nextHeight)
        {
            return nextHeight.HasValue;
        }

        private int GetFarRightWidthInRange(CoordinateRange coordinateRange)
        {
            return this.RectangleList.Last(
                    x => x.Height > coordinateRange.MinY
                    && x.BottomLeftCoordinate.X >= coordinateRange.MinX
                    && x.BottomRightCoordinate.X <= coordinateRange.MaxX)
                .BottomRightCoordinate.X;
        }
    }
}