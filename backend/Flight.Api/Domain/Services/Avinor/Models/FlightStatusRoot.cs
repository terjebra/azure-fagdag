using System.Collections.Generic;
using System.Xml.Serialization;

namespace Flight.Api.Domain.Services.Avinor.Models
{
    [XmlRoot("flightStatuses")]
    public class FlightStatusRoot
    {
        
        [XmlElement("flightStatus")]
        public List<FlightStatus> Stautses { get; set; }
    }
}