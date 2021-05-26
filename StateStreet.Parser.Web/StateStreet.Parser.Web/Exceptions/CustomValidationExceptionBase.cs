using System;
using System.Collections.Generic;
using StateStreet.Parser.Web.Constants;

namespace StateStreet.Parser.Web.Exceptions
{
    //Taken from Hungary notation is not wide used but I like it
    public abstract class CustomValidationExceptionBase : Exception
    {
        protected CustomValidationExceptionBase(IEnumerable<string> errorMessages)
            : this(string.Join(StringConstants.NewLineNonUnixPlatform, errorMessages))
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