using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    [XmlRoot("dataroot")]
    public class SkillCollection
    {
        [XmlElement("character_skills")]
        public List<Skill> Collection { get; set; }
    }
}
