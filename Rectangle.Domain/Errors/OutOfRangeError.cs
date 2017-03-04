namespace Rectangle.Domain.Errors
{
    public class OutOfRangeError : LogicError
    {
        public OutOfRangeError(string message) : base(message)
        {
            
        }
    }
}
