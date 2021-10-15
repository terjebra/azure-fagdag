using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Notification.Storage
{
    public class FlightNotification: TableEntity
    {
        public FlightNotification(string userId, string flightId, string airport)
        {
            Added = DateTimeOffset.UtcNow;
            UserId = userId;
            FlightId = flightId;
            Airport = airport;
            RowKey = $"{userId}_{FlightId}";
            PartitionKey = airport;
        }

        public FlightNotification()
        {
        }

        public DateTimeOffset Added { get; set; }
        public string UserId { get; set; }
        public string FlightId { get; set; }
        public string Airport { get; set; }
    }
}
