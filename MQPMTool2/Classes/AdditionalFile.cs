using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    [XmlInclude(typeof(AdditionalFileDefault)), XmlInclude(typeof(AdditionalFileFova)), XmlInclude(typeof(AdditionalFileFovaFmdl)), XmlInclude(typeof(AdditionalFilePftxs))]
    public abstract class AdditionalFile
    {
        [XmlElement(ElementName = "SourcePath")]
        public string sourcePath;
    } //class
} //namespace
