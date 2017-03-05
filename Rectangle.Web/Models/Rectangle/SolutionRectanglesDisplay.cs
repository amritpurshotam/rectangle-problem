using Rectangle.Domain;

namespace RectangleProblem.Models.Rectangle
{
    public class SolutionRectanglesDisplay
    {
        public SolutionRectanglesDisplay(Grid inputGrid, Grid solutionGrid)
        {
            this.InputGrid = inputGrid;
            this.SolutionGrid = solutionGrid;
        }

        public Grid InputGrid { get; set; }
        public Grid SolutionGrid { get; set; }
    }
}