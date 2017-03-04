using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using LIGate.Domain.Errors;
using Rectangle.Domain.Errors;

namespace Rectangle.Domain.Exceptions
{
    public class LogicException : Exception
    {
        public override string Message
        {
            get
            {
                var message = base.Message;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    return message;
                }
                    
                if (this.Errors.Count == 0)
                {
                    return string.Empty;
                }

                if (this.Errors.Count == 1)
                {
                    return this.Errors.First<LogicError>().Message;
                }

                var stringBuilder = new StringBuilder();
                for (var index = 0; index < this.Errors.Count; ++index)
                {
                    var error = this.Errors[index];
                    stringBuilder.AppendFormat("Error #{0}: {1}\r\n", (object)(index + 1), (object)error.Message);
                }
                return stringBuilder.ToString();
            }
        }

        public LogicErrors Errors { get; set; }

        public LogicException(string message, LogicError error)
            : base(message)
        {
            this.Errors = new LogicErrors {error};
        }

        public LogicException(string message, LogicError error, Exception inner)
            : base(message, inner)
        {
            this.Errors = new LogicErrors {error};
        }

        public LogicException(LogicError error)
            : this(string.Empty, error)
        {
        }

        public LogicException(LogicError error, Exception inner)
            : this(string.Empty, error, inner)
        {
        }

        protected LogicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Errors = new LogicErrors();
        }

        public LogicException(string message, LogicErrors errors)
            : base(message)
        {
            this.Errors = errors;
        }

        public LogicException(LogicErrors errors)
            : this(errors.GetCombinedMessages(), errors)
        {
        }
    }
}
