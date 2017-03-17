using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("PlayerOutfit")]
    public class PlayerOutfit
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("Display")]
        public string display;

        [XmlAttribute("LimitHeads")]
        public bool limitHeads;

        [XmlArray("QuietOutfits")]
        public List<string> quietOutfits = new List<string>(0);
    } //class PlayerOutfit ends
} //namespace MQPMTool2 ends
