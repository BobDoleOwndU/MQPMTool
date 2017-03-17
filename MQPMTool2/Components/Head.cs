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
    } //class Head ends
} //namespace MQPMTool2 ends
