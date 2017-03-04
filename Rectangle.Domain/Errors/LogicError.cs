using Rectangle.Domain.Exceptions;

namespace Rectangle.Domain.Errors
{
    public abstract class LogicError
    {
        protected LogicError(string message)
        {
            this.Message = message;
        }

        protected LogicError() : this(null)
        {
            
        }

        public string Message { get; set; }

        public void Throw()
        {
            throw this.AsException();
        }

        public LogicException AsException()
        {
            return new LogicException(this);
        }
    }
}
