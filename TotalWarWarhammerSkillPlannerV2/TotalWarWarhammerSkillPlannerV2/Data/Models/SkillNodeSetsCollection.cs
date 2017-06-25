using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    [XmlRoot("dataroot")]
    public class SkillNodeSetsCollection
    {
        [XmlElement("character_skill_node_sets")]
        public List<SkillNodeSet> Collection { get; set; }
    }
}
