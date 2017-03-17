using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("QuietOutfit")]
    public class QuietOutfit
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("Display")]
        public string display;

        [XmlAttribute("Fcnp")]
        public string fcnp;

        [XmlAttribute("IncludePftxs")]
        public bool includePftxs;

        [XmlAttribute("UseBody")]
        public bool useBody;

        [XmlAttribute("ExtraFmdl")]
        public string extraFmdl;

        [XmlAttribute("DefaultHead")]
        public string defaultHead;

        [XmlArray("Heads")]
        public List<string> heads = new List<string>(0);

        [XmlArray("Sims")]
        public List<string> sims = new List<string>(0);
    } //class QuietOutfit ends
} //namespace MQPMTool2 ends
