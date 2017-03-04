using System.Collections.ObjectModel;
using System.Web.Mvc;
using Rectangle.Domain.Errors;
using Rectangle.Domain.Exceptions;

namespace RectangleProblem.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddLogicErrors(this ModelStateDictionary modelstate, LogicException ex)
        {
            if (ex.Errors == null || ex.Errors.Count == 0)
            {
                if (string.IsNullOrWhiteSpace(ex.Message))
                {
                    return;
                }
                    
                modelstate.AddModelError("", ex.Message);
            }
            else
            {
                foreach (LogicError error in (Collection<LogicError>) ex.Errors)
                {
                    modelstate.AddModelError("", error.Message);
                }
            }
        }
    }
}