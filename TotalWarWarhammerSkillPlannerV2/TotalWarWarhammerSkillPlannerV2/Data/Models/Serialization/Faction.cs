using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class Faction
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("screen_name")]
        public string Name { get; set; }
    }
}
