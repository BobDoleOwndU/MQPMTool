using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("PlayerType")]
    public class PlayerType
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlArray("PlayerOutfits")]
        public List<string> playerOutfits = new List<string>(0);

        [XmlArray("ExcludedOutfits")]
        public List<string> excludedOutfits = new List<string>(0);
    } //class PlayerType ends
} //namespace MQPMTool2 ends
