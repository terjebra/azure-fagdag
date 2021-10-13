using System.Collections.Generic;
using System.Xml.Serialization;

namespace Flight.Api.Domain.Services.Avinor.Models
{
    [XmlRoot("airlineNames")]
    public class AirlinesRoot
    {
        
        [XmlElement("airlineName")]
        public List<Airline> Airlines { get; set; }
    }
}