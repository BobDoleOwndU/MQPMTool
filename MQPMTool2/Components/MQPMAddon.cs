using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("MQPMAddon")]
    public class MQPMAddon
    {
        [XmlArray("SnakeExcludedOutfits")]
        public List<string> snakeExcludedOutfits = new List<string>(0);

        [XmlArray("FemaleExcludedOutfits")]
        public List<string> femaleExcludedOutfits = new List<string>(0);

        [XmlArray("QuietOutfits")]
        public List<QuietOutfit> quietOutfits = new List<QuietOutfit>(0);

        [XmlArray("Heads")]
        public List<Head> heads = new List<Head>(0);
    } //class Addon ends
}
