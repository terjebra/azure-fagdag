using System.Xml.Serialization;

namespace Flight.Api.Domain.Services.Avinor.Models
{
    [XmlRoot("airport")]
    public class AirportFlightsRoot
    {

        [XmlElement("flights")]
        public AirportFlights AirportFlights { get; set; }
    }
}