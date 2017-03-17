using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("MQPMComponent")]
    public class MQPMComponent
    {
        [XmlArray("PlayerTypes")]
        public List<PlayerType> playerTypes = new List<PlayerType>(0);

        [XmlArray("PlayerOutfits")]
        public List<PlayerOutfit> playerOutfits = new List<PlayerOutfit>(0);

        [XmlArray("QuietOutfits")]
        public List<QuietOutfit> quietOutfits = new List<QuietOutfit>(0);

        [XmlArray("Heads")]
        public List<Head> heads = new List<Head>(0);
    } //class MQPMComponent ends
} //namespace MQPMTool2 ends
