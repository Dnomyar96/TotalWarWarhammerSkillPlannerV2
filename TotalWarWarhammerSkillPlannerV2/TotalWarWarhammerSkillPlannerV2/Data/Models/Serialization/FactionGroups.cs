using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class FactionGroups
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("name_localised")]
        public string Name { get; set; }
    }
}
