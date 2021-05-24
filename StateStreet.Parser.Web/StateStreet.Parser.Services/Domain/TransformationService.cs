using FluentValidation;
using StateStreet.Parser.Services.DomainModels;
using StateStreet.Parser.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using StateStreet.Parser.Services.Exceptions;

namespace StateStreet.Parser.Services.Domain
{
    public class TransformationService : ITransformationService
    {
        private readonly IValidator<EventDto> _validator;
        public TransformationService(IValidator<EventDto> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public IEnumerable<Event> Map(IEnumerable<EventDto> dto)
        {
            var validationResult = dto.Select(d => _validator.Validate(d));
            if (validationResult.Any(vr => vr.IsValid == false))
            {
                throw new InvalidDataToMapException(/*validationResult.Select((vr, index) =>*/  "well formatted string"); 
            }

            return dto.Select(d => new Event(d));
        }
    }
}
