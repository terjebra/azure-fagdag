﻿using System.Xml.Serialization;

namespace Shared.Services.Avinor.Models
{
    public class Airport
    {
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}