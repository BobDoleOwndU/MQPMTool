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

        [XmlArray("MaleExcludedOutfits")]
        public List<string> maleExcludedOutfits = new List<string>(0);

        [XmlArray("AddonOutfits")]
        public List<AddonOutfit> addonOutfits = new List<AddonOutfit>(0);

        [XmlArray("AddonHeads")]
        public List<AddonHead> addonHeads = new List<AddonHead>(0);

        [XmlArray("Fcnps")]
        public List<Fcnp> fcnps = new List<Fcnp>(0);

        [XmlArray("ExtraLists")]
        public List<ExtraList> extraLists = new List<ExtraList>(0);
    } //class Addon ends
}
