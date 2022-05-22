using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class Outfit
    {
        [XmlElement(ElementName = "Name")]
        public string name;

        [XmlElement(ElementName = "MdlPath")]
        public string mdlPath;

        [XmlElement(ElementName = "CnpPath")]
        public string cnpPath;

        [XmlElement(ElementName = "RdvPath")]
        public string rdvPath;

        [XmlArray(ElementName = "Sims")]
        public List<Sim> sims;

        [XmlArray(ElementName = "AdditionalFiles")]
        public List<AdditionalFile> additionalFiles;
    } //class
} //namespace
