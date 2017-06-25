using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class NodeLink
    {
        public string ChildKey { get; set; }
        
        public string ParentKey { get; set; }
        
        public string LinkType { get; set; }
    }
}
