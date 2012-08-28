namespace IDevign.M3.Candy.EventAggregator
{
    /// <summary>
    /// Contract for the EventAggregator
    /// </summary>
    public interface IEventAggregator
    {
        void Subscribe(object subscriber);
        void Unsubscribe(object subscriber);
        TMessage Publish<TMessage>(TMessage message);
    }
}