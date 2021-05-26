using System;
using StateStreet.Parser.Web.DomainModels;

namespace StateStreet.Parser.Web.Models
{
    public class EventModel
    {
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }

        public EventModel(EventData dto)
            => (Name, Description, StartDateTime, EndDateTime)
                = (dto.Name, dto.Description, DateTime.Parse(dto.StartDateTime), DateTime.Parse(dto.EndDateTime));
    }
}
