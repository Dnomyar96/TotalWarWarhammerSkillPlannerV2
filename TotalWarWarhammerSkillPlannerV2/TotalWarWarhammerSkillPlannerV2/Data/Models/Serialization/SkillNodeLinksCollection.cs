using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    [XmlRoot("dataroot")]
    public class SkillNodeLinksCollection
    {
        [XmlElement("character_skill_node_links")]
        public List<SkillNodeLink> Collection { get; set; }
    }
}
