using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class AdditionalFileFovaFmdl : AdditionalFileFova
    {
        [XmlElement(ElementName = "DestinationPath")]
        public string destinationPath;
    } //class
} //namespace
