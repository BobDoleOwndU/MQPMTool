using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("CharacterOutfit")]
    public class CharacterOutfit
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("Display")]
        public string display;

        [XmlAttribute("IncludePftxs")]
        public bool includePftxs;

        [XmlAttribute("UseBody")]
        public bool useBody;

        [XmlAttribute("ExtraList")]
        public string extraList;

        [XmlAttribute("DefaultHead")]
        public string defaultHead;

        [XmlArray("Heads")]
        public List<string> heads = new List<string>(0);

        [XmlArray("Fcnps")]
        public List<string> fcnps = new List<string>(0);

        [XmlArray("Sims")]
        public List<string> sims = new List<string>(0);
    } //class CharacterOutfit ends
} //namespace MQPMTool2 ends
