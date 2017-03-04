using System;
using Rectangle.Domain;
using Rectangle.DomainLogic.Services.Interfaces;

namespace Rectangle.DomainLogic.Services.Implementations
{
    public class GridService : IGridService
    {
        public GridService()
        {
        }

        public Grid InitialiseGrid(byte number)
        {
            var grid = new Grid();

            var random = new Random();
            for (var i = 0; i < number; i++)
            {
                var height = random.Next();
                var width = random.Next();

                var bottomLeftCoordinate = grid.GetNextBottomLeftCoordinate();
                var rectangle = new Domain.Rectangle(bottomLeftCoordinate, height, width);
                
                grid.AddRectangle(rectangle);
            }

            return grid;
        } 
    }
}
