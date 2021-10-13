using System;
using System.Text.Json.Serialization;
using Flight.Api.Domain.Flights;

namespace Flight.Api.Controllers.Flights
{
    public class ApiFlight
    {
        public ApiFlight(QueryFlight queryFlight)
        {
            Id = queryFlight.Id;
            Airline = queryFlight.Airline;
            Airport = queryFlight.Airport;
            Direction = (ApiDirection)queryFlight.Direction;
            CheckIn = queryFlight.CheckIn;
            Delayed = queryFlight.Delayed;
            Travel = (ApiTravel)queryFlight.Travel;
            FlightId = queryFlight.FlightId;
            Gate = queryFlight.Gate;
            ScheduleTime = queryFlight.ScheduleTime;
            ViaAirport = queryFlight.ViaAirport;
            StatusCode = queryFlight.StatusCode;
            StatusTime = queryFlight.StatusTime;
        }

        public string Id { get; set; }
        public string Airline { get; set; } 
        public string Airport { get; set; }
        public ApiDirection Direction { get; set; } 
        public string CheckIn { get; set; }
        public bool Delayed { get; set; }
        public ApiTravel Travel { get; set; }
        public string FlightId { get; set; }
        public string Gate { get; set; } 
        public DateTime ScheduleTime { get; set; }
        public string ViaAirport { get; set; }
        public string StatusCode { get; set; }
        public DateTime? StatusTime { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApiDirection
    {
        Arrival,
        Departure
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApiTravel {
        Domestic,
        International
    }
    
}