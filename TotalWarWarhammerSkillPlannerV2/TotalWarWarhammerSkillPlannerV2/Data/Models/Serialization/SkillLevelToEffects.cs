using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class SkillLevelToEffects
    {
        [XmlElement("character_skill_key")]
        public string SkillKey { get; set; }

        [XmlElement("effect_key")]
        public string EffectKey { get; set; }

        [XmlElement("effect_scope")]
        public string EffectScope { get; set; }

        [XmlElement("is_factionwide")]
        public bool IsFactionwide { get; set; }

        [XmlElement("level")]
        public int Level { get; set; }

        [XmlElement("value")]
        public int Value { get; set; }
    }
}
