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

        public Coordinate GetNextBottomLeftCoordinateForStackedRectangles()
        {
            if (!this.RectangleList.Any())
            {
                return new Coordinate(0, 0);
            }

            return this.RectangleList.First().TopLeftCoordinate;
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
            coordinateRangeQueue.Enqueue(new CoordinateRange(0, 0, this.RectangleList.Last().BottomRightCoordinate.X));
            var rectangleId = 1;

            while (coordinateRangeQueue.Any())
            {
                var coordinateRange = coordinateRangeQueue.Dequeue();
                var nextHeight = this.GetShortestHeightInCoordinateRange(coordinateRange);

                if (this.CanStackMoreRectangles(nextHeight))
                {
                    var shortestRectangles = this.GetRectanglesWithExactHeightInCoordinateRange(nextHeight.Value, coordinateRange);

                    coordinateRangeQueue.Enqueue(new CoordinateRange(nextHeight.Value, coordinateRange.MinX, shortestRectangles[0].TopLeftCoordinate.X));
                    
                    for (int i = 0; i < shortestRectangles.Length; i++)
                    {
                        if (i < shortestRectangles.Length - 1)
                        {
                            coordinateRangeQueue.Enqueue(new CoordinateRange(nextHeight.Value,
                                shortestRectangles[i].TopRightCoordinate.X,
                                shortestRectangles[i + 1].TopLeftCoordinate.X));
                        }
                        else
                        {
                            if (shortestRectangles[i].RectangleId < this.RectangleList.Count)
                            {

                                if (shortestRectangles[i].Height < this.RectangleList.Single(x => x.RectangleId == (shortestRectangles[i].RectangleId + 1)).Height)
                                {
                                    coordinateRangeQueue.Enqueue(new CoordinateRange(nextHeight.Value,
                                        shortestRectangles[i].TopRightCoordinate.X,
                                        this.GetFarRightWidthInRange(coordinateRange)));
                                }
                            }
                            
                        }
                    }

                    var rectangle = new Rectangle(rectangleId, new Coordinate(coordinateRange.MinX, coordinateRange.MinY), nextHeight.Value - coordinateRange.MinY, coordinateRange.MaxX - coordinateRange.MinX);
                    rectangleId++;
                    grid.AddRectangle(rectangle);
                }
            }

            return grid;
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