using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    [XmlRoot("dataroot")]
    public class SkillNodesCollection
    {
        [XmlElement("character_skill_nodes")]
        public List<SkillNode> Collection { get; set; }
    }
}
