using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class Sim
    {
        [XmlElement(ElementName = "Name")]
        public string name;

        [XmlElement(ElementName = "Path")]
        public string path;

        [XmlElement(ElementName = "IsActive")]
        public bool isActive;
    } //class
} //namespace
