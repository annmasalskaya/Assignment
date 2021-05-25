using FluentValidation;
using StateStreet.Parser.Web.DomainModels;

namespace StateStreet.Parser.Web.Validation
{
    public class InputDataValidator : AbstractValidator<RawEventData>
    {
        public InputDataValidator()
        {
            RuleForEach(input => input.RawEvents)
                .Must(items => items.Length == 4)
                .WithMessage("Badly formatted input data at row # {CollectionIndex}");
        }
    }
}