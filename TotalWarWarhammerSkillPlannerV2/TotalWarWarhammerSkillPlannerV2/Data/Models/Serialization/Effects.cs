using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class Effects
    {
        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("effect")]
        public string Effect { get; set; }

        [XmlElement("icon")]
        public string Icon { get; set; }

        [XmlElement("icon_negative")]
        public string IconNegative { get; set; }

        [XmlElement("is_positive_value_good")]
        public bool IsPositiveValueGood { get; set; }

        [XmlElement("priority")]
        public int Priority { get; set; }
    }
}
