using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization
{
    public class SkillNodeLink
    {
        /// <summary>
        /// Current skill
        /// </summary>
        [XmlElement("child_key")]
        public string ChildKey { get; set; }

        /// <summary>
        /// Required skill
        /// </summary>
        [XmlElement("parent_key")]
        public string ParentKey { get; set; }
        
        [XmlElement("link_type")]
        public string LinkType { get; set; }
    }
}
