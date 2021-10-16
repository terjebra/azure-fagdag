using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Shared.Services.Avinor.Models
{
    public class AirportFlights
    {

        [XmlElement("flight")]
        public List<Flight> Flights { get; set; }

        [XmlAttribute("lastUpdate")]
        public DateTime LastUpdated { get; set; }
    }
}