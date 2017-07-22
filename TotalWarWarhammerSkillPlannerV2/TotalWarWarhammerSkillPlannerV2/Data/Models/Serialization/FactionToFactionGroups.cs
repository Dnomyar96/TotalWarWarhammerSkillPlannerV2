using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class FactionToFactionGroups
    {
        [XmlElement("faction_group_key")]
        public string FactionGroupKey { get; set; }

        [XmlElement("faction_key")]
        public string FactionKey { get; set; }
    }
}
