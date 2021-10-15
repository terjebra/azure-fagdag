namespace Flight.Api.Domain.FlightSubscriptions
{
    public class FlightNotificationMessage
    {
        public FlightNotificationMessage(string userId, string flightId, string airport)
        {
            UserId = userId;
            FlightId = flightId;
            Airport = airport;
        }
        public string UserId { get; set; }
        public string FlightId { get; set; }
        public string Airport { get; set; }
    }
}