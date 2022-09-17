using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Text;

namespace TweetApp.Api.EventHub
{
    public class ProducerMessage<TValue> : IDisposable, IProducerMessage<TValue> where TValue : class
    {
        EventHubProducerClient _producer;
        public ProducerMessage(IConfigurationSection eventHubConfig)
        {
            _producer = new EventHubProducerClient(eventHubConfig["connectionstring"], eventHubConfig["EventHubName"]);
        }
        public async void Dispose()
        {
            await _producer.DisposeAsync();
        }

        public async Task ProduceAsync(TValue value)
        {
            using EventDataBatch eventBatch = await _producer.CreateBatchAsync();
            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event {value}")));
            await _producer.SendAsync(eventBatch);
        }
    }
}
