namespace TweetApp.Api.EventHub
{
    public interface IProducerMessage<in TValue> where TValue : class
    {
        Task ProduceAsync(TValue value);
    }
}
