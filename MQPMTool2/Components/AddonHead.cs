using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("AddonHead")]
    public class AddonHead : Head
    {
        [XmlArray("CharacterOutfits")]
        public List<string> characterOutfits = new List<string>(0);
    } //class AddonHead ends
} //namespace MQPMTool2 ends
