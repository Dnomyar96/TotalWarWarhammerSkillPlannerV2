using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    [XmlRoot("dataroot")]
    public class AgentSubTypesCollection
    {
        [XmlElement("agent_subtypes")]
        public List<AgentSubType> Collection { get; set; }
    }
}
