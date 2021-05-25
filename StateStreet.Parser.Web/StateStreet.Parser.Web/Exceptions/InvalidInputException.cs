using System.Collections.Generic;

namespace StateStreet.Parser.Web.Exceptions
{
    public class InvalidInputException : CustomValidationExceptionBase
    {
        public InvalidInputException(IEnumerable<string> errorMessages): base(errorMessages)
        {
        }
    }
}