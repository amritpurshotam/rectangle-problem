﻿using Rectangle.Domain;

namespace Rectangle.DomainLogic.Services.Interfaces
{
    public interface IGridService
    {
        Grid InitialiseWithRectanglesOfRandomSize(byte number);
    }
}