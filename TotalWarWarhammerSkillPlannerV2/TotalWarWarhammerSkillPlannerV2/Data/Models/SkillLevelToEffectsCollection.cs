using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    [XmlRoot("dataroot")]
    public class SkillLevelToEffectsCollection
    {
        [XmlElement("character_skill_level_to_effects_junctions")]
        public List<SkillLevelToEffects> Collection { get; set; } 
    }
}
