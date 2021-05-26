namespace StateStreet.Parser.Web.DomainModels
{
    //Domain models are record type as we are passing objects to service and they have to be immutable to prevent unexpected changes
    public record EventData
    {
        public EventData(string[] rawEvent)
        {
            Name = rawEvent[0];
            Description = rawEvent[1];
            StartDateTime = rawEvent[2];
            EndDateTime = rawEvent[3];
        }

        public string Name { get; }
        public string Description { get; }
        public string StartDateTime { get; }
        public string EndDateTime { get; }
    }
}
