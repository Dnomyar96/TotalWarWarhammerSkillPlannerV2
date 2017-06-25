using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class SkillNodeSet
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("agent_key")]
        public string AgentKey { get; set; }

        [XmlElement("agent_subtype_key")]
        public string AgentSubypeKey { get; set; }

        [XmlElement("enc_title")]
        public string EncTitle { get; set; }
    }
}
