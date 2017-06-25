using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class NodeLink
    {
        /// <summary>
        /// Current skill
        /// </summary>
        public string ChildKey { get; set; }
        
        /// <summary>
        /// Required skill
        /// </summary>
        public string ParentKey { get; set; }
        
        public string LinkType { get; set; }
    }
}
