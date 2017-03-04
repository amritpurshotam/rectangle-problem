using System.Collections.ObjectModel;
using System.Text;
using Rectangle.Domain.Errors;
using Rectangle.Domain.Exceptions;

namespace LIGate.Domain.Errors
{
    public class LogicErrors : Collection<LogicError>
    {
        public bool HasErrors
        {
            get
            {
                return this.Count > 0;
            }
        }

        /// <summary>
        /// Throws a LogicException with all errors in this list.
        /// Will NOT throw an exception if there are no errors.
        /// </summary>
        public void ThrowExceptionIfErrors()
        {
            if (this.HasErrors)
                throw new LogicException(this);
        }

        /// <summary>
        /// Returns a list of all the error messages in all logic errors.
        /// </summary>
        /// <returns></returns>
        public string GetCombinedMessages()
        {
            var stringBuilder = new StringBuilder();
            foreach (var logicError in (Collection<LogicError>)this)
            {
                stringBuilder.AppendLine(logicError.Message ?? logicError.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
