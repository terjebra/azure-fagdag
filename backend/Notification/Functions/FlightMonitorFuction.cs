using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notification.Storage;
using Shared.Services.Avinor;
using Shared.Services.Avinor.Models;

namespace Notification.Functions
{
    class FlightMonitorFunction
    {
        private readonly ITableClient _tableClient;
        private readonly IAvinorApiClient _apiClient;

        public FlightMonitorFunction(ITableClient tableClient, IAvinorApiClient apiClient)
        {
            _tableClient = tableClient;
            _apiClient = apiClient;
        }

        [FunctionName("flight-monitor")]
        public async Task Run([TimerTrigger("0 */3 * * * *", RunOnStartup = true),] TimerInfo myTimer, 
            [SignalR(HubName = "flightnotifications")]IAsyncCollector<SignalRMessage> signalRMessages,ILogger log)
        {
            var subscriptions = await GetAll();

            if (!subscriptions.Any())
            {
                log.LogInformation("No subscriptions found");
                return;
            }

            var groupedByAirports = subscriptions.GroupBy(x => x.Airport);

            var flights = await GetFlights(groupedByAirports);

            if (!flights.Any())
            {
                log.LogInformation("No flights changes found");
            }
            
            foreach (var subscription in subscriptions)
            {
                
                if (flights.Contains(subscription.FlightId))
                {
                    var currentFlight = flights[subscription.FlightId].FirstOrDefault();

                    await signalRMessages.AddAsync(
                        new SignalRMessage
                        {
                            GroupName = subscription.FlightId,
                            Target = "flights",
                            UserId = subscription.UserId,
                            Arguments = new object[]
                            {
                                JsonConvert.SerializeObject(currentFlight
                                    , new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()})
                            }
                        });
                }
            }
        }

        private async Task<ILookup<string, Flight>> GetFlights(IEnumerable<IGrouping<string, FlightNotification>> groupedByAirports)
        {
            //To easy?
            var lastChanged = DateTime.UtcNow.Subtract(new TimeSpan(0, 0, 3, 0));

            var allFlights = new List<Flight>();

            foreach (var airPortGroup in groupedByAirports)
            {
                allFlights.AddRange(await _apiClient.GetFlights(airPortGroup.Key, lastChanged));
            }

            return allFlights.ToLookup(x => x.FlightId, x=> x);
        }

        private async Task<List<FlightNotification>> GetAll()
        {
            var subscriptions = GetSubscriptions().GetAsyncEnumerator();

            try
            {
                while (await subscriptions.MoveNextAsync())
                {
                    var data = subscriptions.Current;

                    return data;
                }
            }
            finally
            {
                await subscriptions.DisposeAsync();
            }

            return new List<FlightNotification>();
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
