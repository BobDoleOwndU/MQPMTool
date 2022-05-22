using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class AdditionalFileFova : AdditionalFile
    {
        [XmlElement(ElementName = "TargetPath")]
        public string targetPath;
    } //AdditionalFileFova
} //namespace
