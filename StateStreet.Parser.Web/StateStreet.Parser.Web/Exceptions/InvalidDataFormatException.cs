using System.Collections.Generic;

namespace StateStreet.Parser.Web.Exceptions
{
    public class InvalidDataFormatException : CustomValidationExceptionBase
    {
        public InvalidDataFormatException(IEnumerable<string> errorMessages) : base(errorMessages)
        {
        }
    }
}
