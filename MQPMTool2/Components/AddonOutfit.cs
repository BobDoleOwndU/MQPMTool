using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("AddonOutfit")]
    public class AddonOutfit : CharacterOutfit
    {
        [XmlArray("PlayerOutfits")]
        public List<string> playerOutfits = new List<string>(0);
    } //class AddonOutfit ends
} //namespace MQPMTool2 ends
