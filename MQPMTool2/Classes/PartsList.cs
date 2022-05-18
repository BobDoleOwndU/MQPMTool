using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class PartsList
    {
        [XmlArray(ElementName = "List")]
        public List<Parts> list = new List<Parts>();
    } //class
} //namespace
