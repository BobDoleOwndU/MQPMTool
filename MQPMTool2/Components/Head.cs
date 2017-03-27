using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("Head")]
    public class Head
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("Display")]
        public string display;

        [XmlAttribute("IncludePftxs")]
        public bool includePftxs;

        [XmlAttribute("UseFv2")]
        public bool useFv2;

        [XmlArray("Values")]
        public List<string> values = new List<string>(0);
    } //class Head ends
} //namespace MQPMTool2 ends
