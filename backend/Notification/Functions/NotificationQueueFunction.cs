using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Notification.Storage;

namespace Notification.Functions
{
    public class NotificationsQueueFunction
    {
        private readonly ITableClient _tableClient;

        public NotificationsQueueFunction(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }
        
        [FunctionName("notifications-queue")]
        public async Task NotificationQueueFunction(
            [ServiceBusTrigger("flight-notifications-queue", Connection = "AzureWebJobsServiceBus")] 
            string queueItem,
            [SignalR(HubName = "flightnotifications")]IAsyncCollector<SignalRGroupAction> signalRMessages,
            ILogger log)
        {

            log.LogInformation(queueItem);
            var message = JsonConvert.DeserializeObject<FlightNotificationMessage>(queueItem);

            var table = await _tableClient.GetTableReference(TableNames.Subscriptions);

            var notification = new FlightNotification(message.UserId, message.FlightId, message.Airport);

            await table.ExecuteAsync(TableOperation.InsertOrReplace(notification));

            try
            {
                await signalRMessages.AddAsync(
                    new SignalRGroupAction
                    {
                        UserId = message.UserId,
                        GroupName = message.FlightId,
                        Action = GroupAction.Add,
                    });
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
        }
        
        private class FlightNotificationMessage
        {
            public string UserId { get; set; }
            public string FlightId { get; set; }
            public string Airport { get; set; }
        }
    }
}
