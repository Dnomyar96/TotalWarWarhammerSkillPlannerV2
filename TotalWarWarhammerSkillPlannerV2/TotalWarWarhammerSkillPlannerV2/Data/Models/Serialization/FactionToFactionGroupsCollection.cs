using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    [XmlRoot("dataroot")]
    public class FactionToFactionGroupsCollection
    {
        [XmlElement("faction_to_faction_groups_junctions")]
        public List<FactionToFactionGroups> Collection { get; set; }
    }
}
