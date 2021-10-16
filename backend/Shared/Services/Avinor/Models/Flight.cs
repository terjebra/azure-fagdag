using System;
using System.Xml.Serialization;

namespace Shared.Services.Avinor.Models
{
    public class Flight
    {

        [XmlElement("airline")] public string Airline { get; set; }
        [XmlElement("airport")] public string Airport { get; set; }
        [XmlElement("arr_dep")] public string ArrivalDeparture { get; set; }
        [XmlElement("check_in")] public string CheckIn { get; set; }
        [XmlElement("delayed")] public string Delayed { get; set; }
        [XmlElement("dom_int")] public string DomesticInternational { get; set; }
        [XmlElement("flight_id")] public string FlightId { get; set; }
        [XmlElement("gate")] public string Gate { get; set; }
        [XmlElement("schedule_time")] public DateTime ScheduleTime { get; set; }
        [XmlElement("via_airport")] public string ViaAirport { get; set; }
        [XmlElement("status")] public AirportFlightStatus Status { get; set; }
        [XmlAttribute("uniqueID")] public string Id { get; set; }
    }
}