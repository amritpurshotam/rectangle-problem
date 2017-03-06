namespace Rectangle.DomainLogic.Tests.Grid
{
    internal static class GridStubs
    {
        internal static Domain.Grid GridStub
        {
            get
            {
                var grid = new Domain.Grid();
                grid.AddRectangle(new Domain.Rectangle(1, new Domain.Coordinate(0,0), 4, 2));
                grid.AddRectangle(new Domain.Rectangle(2, grid.GetNextBottomLeftCoordinate(), 2, 1));
                return grid;
            }
        }

        internal static Domain.Grid GridStub2
        {
            get
            {
                var grid = new Domain.Grid();
                grid.AddRectangle(new Domain.Rectangle(1, new Domain.Coordinate(0, 0), 4, 2));
                grid.AddRectangle(new Domain.Rectangle(2, grid.GetNextBottomLeftCoordinate(), 2, 1));
                grid.AddRectangle(new Domain.Rectangle(3, grid.GetNextBottomLeftCoordinate(), 3, 4));
                return grid;
            }
        }
    }
}
