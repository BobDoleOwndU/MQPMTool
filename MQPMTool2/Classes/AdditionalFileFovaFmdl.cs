using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class AdditionalFileFovaFmdl : AdditionalFile
    {
        [XmlElement(ElementName = "TargetPath")]
        public string targetPath;

        [XmlElement(ElementName = "DestinationPath")]
        public string destinationPath;
    } //class
} //namespace
