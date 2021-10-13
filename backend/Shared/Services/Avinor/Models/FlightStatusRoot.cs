using System.Collections.Generic;
using System.Xml.Serialization;

namespace Shared.Services.Avinor.Models
{
    [XmlRoot("flightStatuses")]
    public class FlightStatusRoot
    {
        
        [XmlElement("flightStatus")]
        public List<FlightStatus> Stautses { get; set; }
    }
}