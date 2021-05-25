using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Logging;
using StateStreet.Parser.Web.DomainModels;
using StateStreet.Parser.Web.Exceptions;

namespace StateStreet.Parser.Web.Services
{
    public class ValidationService
    {
        private readonly IValidator<RawEventData> _rawEventDataValidator;
        private readonly IValidator<EventData> _eventDataValidator;
        private readonly ILogger<ValidationService> _logger;
        public ValidationService(IValidator<EventData> eventDataValidator, IValidator<RawEventData> rawEventDataValidator, ILogger<ValidationService> logger)
        {
            _eventDataValidator = eventDataValidator ?? throw new ArgumentNullException(nameof(eventDataValidator));
            _rawEventDataValidator = rawEventDataValidator ?? throw new ArgumentNullException(nameof(rawEventDataValidator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void ValidateInputData(RawEventData data)
        {
            try
            {
                var validationResult = _rawEventDataValidator.Validate(data);
                if (validationResult.IsValid == false)
                {
                    throw new InvalidInputException(validationResult.Errors.Select(error => error.ErrorMessage));
                }
            }
            //Validation via exceptions is not really good design but quick to implement
            //https://stackoverflow.com/questions/1504302/is-it-a-good-or-bad-idea-throwing-exceptions-when-validating-data
            catch (InvalidInputException exception)
            {
                _logger.LogError(exception.Message);
            }
        }

        public void ValidateEventData(EventData[] data)
        {
            try
            {
                var validationErrorMessages = ValidateEachEventDataItem(data).ToArray(); // To Prevent Multiple Enumeration

                if (validationErrorMessages.Any())
                {
                    throw new InvalidDataFormatException(validationErrorMessages.Select(em => em));
                }
            }
            catch (InvalidDataFormatException exception)
            {
                _logger.LogError(exception.Message);
            }
        }

        private IEnumerable<string> ValidateEachEventDataItem(EventData[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                var validationResult = _eventDataValidator.Validate(data[i]);
                if (validationResult.IsValid == false)
                {
                    yield return $"The following errors in row #{i + 1}: {string.Join("\n\r", validationResult)}";
                }
            }
        }
    }
}
