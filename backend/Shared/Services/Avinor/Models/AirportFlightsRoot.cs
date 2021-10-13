using System.Xml.Serialization;

namespace Shared.Services.Avinor.Models
{
    [XmlRoot("airport")]
    public class AirportFlightsRoot
    {

        [XmlElement("flights")]
        public AirportFlights AirportFlights { get; set; }
    }
}