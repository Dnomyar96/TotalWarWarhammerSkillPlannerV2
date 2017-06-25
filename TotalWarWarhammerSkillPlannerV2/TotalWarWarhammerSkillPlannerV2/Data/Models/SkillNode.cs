using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    [XmlRoot("dataroot")]
    public class SkillNode
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("character_skill_key")]
        public string CharacterSkillKey { get; set; }

        [XmlElement("character_skill_node_set_key")]
        public string CharcterSkillNodeSetKey { get; set; }

        [XmlElement("indent")]
        public int Indent { get; set; }

        [XmlElement("tier")]
        public int Tier { get; set; }

        [XmlElement("visible_in_ui")]
        public bool VisibleInUi { get; set; }
    }
}
