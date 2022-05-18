using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2.Classes
{
    [XmlType]
    public class OutfitList
    {
        [XmlArray(ElementName = "List")]
        public List<Outfit> list = new List<Outfit>();
    } //class
} //namespace
