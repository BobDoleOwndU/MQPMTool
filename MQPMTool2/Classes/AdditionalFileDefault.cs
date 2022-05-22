using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class AdditionalFileDefault : AdditionalFile
    {
        [XmlElement(ElementName = "DestinationPath")]
        public string destinationPath;
    } //class
} //namespace
