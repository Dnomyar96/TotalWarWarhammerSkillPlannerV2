using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class NodeSet
    {
        public string Key { get; set; }
        
        public string AgentKey { get; set; }
        
        public string AgentSubtypeKey { get; set; }
        
        public string EncTitle { get; set; }

        public IEnumerable<Node> Nodes { get; set; }
    }
}
