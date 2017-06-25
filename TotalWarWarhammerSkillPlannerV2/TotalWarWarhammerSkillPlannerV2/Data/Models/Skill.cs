using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class Skill
    {

        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("localised_name")]
        public string Name { get; set; }

        [XmlElement("unlocked_at_rank")]
        public int UnlockedAtRank { get; set; }

        [XmlElement("localised_description")]
        public string Description { get; set; }

        [XmlElement("image_path")]
        public string ImagePath { get; set; }
    }
}
