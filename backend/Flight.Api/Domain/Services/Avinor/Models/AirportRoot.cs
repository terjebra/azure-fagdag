using System.Collections.Generic;
using System.Xml.Serialization;

namespace Flight.Api.Domain.Services.Avinor.Models
{
    [XmlRoot("airportNames")]
    public class AirportRoot
    {
        
        [XmlElement("airportName")]
        public List<Airport> Airports { get; set; }
    }
}