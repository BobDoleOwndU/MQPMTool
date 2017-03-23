using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("Fcnp")]
    public class Fcnp
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("Display")]
        public string display;
    } //class Fcnp ends
} //namespace MQPMTool2 ends
