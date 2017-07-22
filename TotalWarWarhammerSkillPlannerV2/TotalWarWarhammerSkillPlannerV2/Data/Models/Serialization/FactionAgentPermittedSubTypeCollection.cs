using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    [XmlRoot("dataroot")]
    public class FactionAgentPermittedSubTypeCollection
    {
        [XmlElement("faction_agent_permitted_subtypes")]
        public List<SkillNodeSet> Collection { get; set; }
    }
}
