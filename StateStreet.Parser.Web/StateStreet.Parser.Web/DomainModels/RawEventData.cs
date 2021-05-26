using System.Collections.Generic;

namespace StateStreet.Parser.Web.DomainModels
{
    public record RawEventData
    {
        public IEnumerable<string[]> RawEvents { get; }

        public RawEventData(IEnumerable<string[]> rawEvents)
        {
            RawEvents = rawEvents;
        }
    }
}