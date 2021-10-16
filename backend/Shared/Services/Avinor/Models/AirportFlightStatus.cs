using System;
using System.Xml.Serialization;

namespace Shared.Services.Avinor.Models
{
    public class AirportFlightStatus
    {
        [XmlAttribute("code")] 
        public string Code { get; set; }
        [XmlAttribute("time")] 
        public DateTime Time { get; set; }
    }
}