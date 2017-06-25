using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class AgentSubType
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("onscreen_name_override")]
        public string OnscreenNameOverride { get; set; }

        [XmlElement("description_text_override")]
        public string DescriptionTextOverride { get; set; }

        [XmlElement("associated_unit_override")]
        public string AssociatedUnitOverride { get; set; }

        [XmlElement("auto_generate")]
        public bool AutoGenerate { get; set; }

        [XmlElement("has_female_name")]
        public bool HasFemaleName { get; set; }

        [XmlElement("is_caster")]
        public bool IsCaster { get; set; }

        [XmlElement("show_in_ui")]
        public bool ShowInUi { get; set; }

        [XmlElement("small_icon")]
        public string SmallIcon { get; set; }
    }
}
