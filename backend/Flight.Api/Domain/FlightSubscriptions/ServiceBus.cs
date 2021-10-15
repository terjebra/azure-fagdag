using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Flight.Api.Extensions;
using Microsoft.Extensions.Configuration;

namespace Flight.Api.Domain.FlightSubscriptions
{
    public class ServiceBus : IServiceBus
    {
        private readonly string _connectionString;
        private readonly string _queueName;

        public ServiceBus(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ServiceBus:ConnectionStrings");
            _queueName = configuration.GetValue<string>("ServiceBus:QueueName");
        }

        public async Task SendMessage<T>(T message)
        {
            try
            {
                await using var client = new ServiceBusClient(_connectionString);
                var sender = client.CreateSender(_queueName);
                await sender.SendAsJsonAsync(message);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to send message",e);
            }
        }
    }
}