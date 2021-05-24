using StateStreet.Parser.Services.DomainModels;
using StateStreet.Parser.Services.Dto;
using System.Collections.Generic;

namespace StateStreet.Parser.Services.Domain
{
    public interface ITransformationService
    {
        IEnumerable<Event> Map(IEnumerable<EventDto> dto);
    }
}
