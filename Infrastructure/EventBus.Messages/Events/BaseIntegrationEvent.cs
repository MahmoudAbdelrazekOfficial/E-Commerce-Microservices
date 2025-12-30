namespace EventBus.Messages.Events
{
    public class BaseIntegrationEvent
    {
        public string CorrelationId { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseIntegrationEvent()
        {
            CorrelationId = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
        }
        public BaseIntegrationEvent(Guid corrlationId , DateTime creationDate)
        {
            CorrelationId = corrlationId.ToString();
            CreationDate = creationDate;
        }
    }
}
