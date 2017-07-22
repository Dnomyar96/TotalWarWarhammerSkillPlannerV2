using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class FactionAgentPermittedSubtypes
    {
        [XmlElement("faction")]
        public string Faction { get; set; }

        [XmlElement("subtype")]
        public string AgentSubType { get; set; }
    }
}
