using System.Collections.Generic;
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

        [XmlArray(ElementName = "Fovas")]
        public List<string> fovas;
    } //class
} //namespace
