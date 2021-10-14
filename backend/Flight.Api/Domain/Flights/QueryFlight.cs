using System;

namespace Flight.Api.Domain.Flights
{
    public class QueryFlight
    {
        public string Id { get; set; }
        public string Airline { get; set; } 
        public string Airport { get; set; }
        public Direction Direction { get; set; } 
        public string CheckIn { get; set; }
        public bool Delayed { get; set; }
        public Travel Travel { get; set; }
        public string FlightId { get; set; }
        public string Gate { get; set; } 
        public DateTime ScheduleTime { get; set; }
        public string ViaAirport { get; set; }
        public string StatusCode { get; set; }
        public DateTime? StatusTime { get; set; }
    }

    public enum Direction
    {
        Arrival,
        Departure
    }

    public enum Travel {
        Domestic,
        International
    }
    
}