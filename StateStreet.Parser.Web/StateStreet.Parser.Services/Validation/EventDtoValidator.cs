using FluentValidation;
using StateStreet.Parser.Services.Dto;
using System;

namespace StateStreet.Parser.Services.Validation
{
    public class EventDtoValidator : AbstractValidator<EventDto>
    {
        private const string DateFormat = "yyyy-MM-ddTHH:mmzzz";
        public EventDtoValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Event Name must not be empty")
                .MaximumLength(32).WithMessage("The length of Event Name must be 32 characters or fewer");


            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Event Description must not be empty")
                .MaximumLength(255).Matches(@"[^\;]+").WithMessage("Event Description should be up to 255 characters long");

            RuleFor(e => e.StartDateTime).Must(BeValidDate).WithMessage($"Start Date should be {DateFormat}");

            RuleFor(e => e.EndDateTime)
                .Must(BeValidDate).WithMessage($"End Date format should be {DateFormat}")
                .GreaterThanOrEqualTo(x => x.StartDateTime).WithMessage("End Date must be equal or after Start Date");
        }

        private bool BeValidDate(string value)
        {
            return DateTime.TryParseExact(value, DateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }
    }
}
