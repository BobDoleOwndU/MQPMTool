using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("ExtraList")]
    public class ExtraList
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("IncludeFrdv")]
        public bool includeFrdv;

        [XmlArray("Values")]
        public List<string> values = new List<string>(0);
    } //class ExtraList ends
} //namespace MQPMTool2 ends
