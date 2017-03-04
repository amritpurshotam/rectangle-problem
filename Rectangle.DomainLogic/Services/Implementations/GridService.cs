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
            const byte minLength = 1;
            const byte maxLength = 10;
            var random = new Random();

            var grid = new Grid();
            for (var i = 0; i < number; i++)
            {
                var height = random.Next(minLength, maxLength);
                var width = random.Next(minLength, maxLength);

                var bottomLeftCoordinate = grid.GetNextBottomLeftCoordinate();
                var rectangle = new Domain.Rectangle(bottomLeftCoordinate, height, width);
                
                grid.AddRectangle(rectangle);
            }

            return grid;
        } 
    }
}
