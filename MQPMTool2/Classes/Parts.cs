using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class Parts
    {
        [XmlElement(ElementName = "Name")]
        public string name;

        [XmlElement(ElementName = "FpkPath")]
        public string fpkPath;

        [XmlElement(ElementName = "PartsPath")]
        public string partsPath;
    } //class
} //namespace
