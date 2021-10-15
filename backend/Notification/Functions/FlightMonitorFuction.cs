using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notification.Storage;

namespace Notification.Functions
{
    class FlightMonitorFunction
    {
        private readonly ITableClient _tableClient;

        public FlightMonitorFunction(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }


        [FunctionName("flight-monitor")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, 
            [SignalR(HubName = "flightnotifications")]IAsyncCollector<SignalRMessage> signalRMessages,ILogger log)
        {
            var subscriptions =  GetSubscriptions().GetAsyncEnumerator();

            try
            {
                while (await subscriptions.MoveNextAsync())
                {
                    var data = subscriptions.Current;

                    foreach (var datum in data)
                    {
                        await signalRMessages.AddAsync(
                            new SignalRMessage
                            {
                                GroupName = datum.FlightId,
                                Target = "flights",
                                UserId = datum.UserId,
                                Arguments = new object[]
                                {
                                    JsonConvert.SerializeObject(datum
                                    , new JsonSerializerSettings{ ContractResolver = new CamelCasePropertyNamesContractResolver()})
                                }
                            });
                    }
                   
                }
            }
            finally
            {
                await subscriptions.DisposeAsync();
            }

        }

        private async IAsyncEnumerable<List<FlightNotification>> GetSubscriptions()
        {
            var table = await _tableClient.GetTableReference(TableNames.Subscriptions);

            var query = new TableQuery<FlightNotification>();
            TableContinuationToken continuationToken = null;
            do
            {
                var page = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
                continuationToken = page.ContinuationToken;
                yield return page.Results;
            } while (continuationToken != null);
        }
    }
}
