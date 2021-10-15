using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Flight.Api.Extensions
{
    public static class ServiceBusSenderExtensions
    {
        public static async Task SendAsJsonAsync<T>(this ServiceBusSender messageSender, T payload)
        {
            var messagePayload = JsonSerializer.Serialize(payload);
            var queueMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(messagePayload));
            await messageSender.SendMessageAsync(queueMessage);
        }
    }
}