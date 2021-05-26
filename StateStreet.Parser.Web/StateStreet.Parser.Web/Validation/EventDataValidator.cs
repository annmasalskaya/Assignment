using System;
using System.Globalization;
using FluentValidation;
using StateStreet.Parser.Web.Constants;
using StateStreet.Parser.Web.DomainModels;

namespace StateStreet.Parser.Web.Validation
{
    public class EventDataValidator : AbstractValidator<EventData>
    {

        public EventDataValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Event Name must not be empty.")
                .MaximumLength(32).WithMessage("The length of Event Name must be 32 characters or fewer.");


            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Event Description must not be empty.")
                .MaximumLength(255).Matches(@"[^\;]+")
                .WithMessage("Event Description should be up to 255 characters long.");

            RuleFor(e => e.StartDateTime)
                .Must(BeValidDate)
                .WithMessage($"Start Date should be {StringConstants.DateFormat}.");

            RuleFor(e => e.EndDateTime)
                .Must(BeValidDate).WithMessage($"End Date format should be {StringConstants.DateFormat}.")
                .Must(BeGreaterThan).WithMessage("End Date needs to be greater than Start Date");
        }

        private bool BeValidDate(string value)
        {
            return DateTime.TryParseExact(value, StringConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        private bool BeGreaterThan(EventData instance, string endDate)
        {
            return (DateTime.Parse(instance.StartDateTime, CultureInfo.InvariantCulture) <= DateTime.Parse(endDate, CultureInfo.InvariantCulture));
        }
    }
}
