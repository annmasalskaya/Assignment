using StateStreet.Parser.Services.Dto;
using System;

namespace StateStreet.Parser.Services.DomainModels
{
    public record Event
    {
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }

        public Event(EventDto dto)
            => (Name, Description, StartDateTime, EndDateTime)
                = (dto.Name, dto.Description, DateTime.Parse(dto.StartDateTime), DateTime.Parse(dto.EndDateTime));
    }
}
