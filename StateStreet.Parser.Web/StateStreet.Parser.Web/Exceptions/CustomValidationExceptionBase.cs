using System;
using System.Collections.Generic;

namespace StateStreet.Parser.Web.Exceptions
{
    //Taken from Hungary notation is not wide used but I like it
    public abstract class CustomValidationExceptionBase : Exception
    {
        protected CustomValidationExceptionBase(IEnumerable<string> errorMessages)
            : this(string.Join("\n\r", errorMessages))
        {
        }

        protected CustomValidationExceptionBase()
        {
        }

        protected CustomValidationExceptionBase(string message) : base(message)
        {
        }

        protected CustomValidationExceptionBase(string message, Exception inner) : base(message, inner)
        {
        }
    }
}