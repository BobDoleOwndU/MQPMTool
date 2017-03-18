using System.Collections.Generic;
using System.Xml.Serialization;

namespace MQPMTool2
{
    [XmlType("AddonHead")]
    public class AddonHead : Head
    {
        [XmlArray("QuietOutfits")]
        public List<string> quietOutfits = new List<string>(0);
    } //class AddonHead ends
} //namespace MQPMTool2 ends
