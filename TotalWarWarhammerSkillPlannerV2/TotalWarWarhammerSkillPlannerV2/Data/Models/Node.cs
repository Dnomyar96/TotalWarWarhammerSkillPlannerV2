using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class Node
    {
        public string Key { get; set; }
        
        public string CharacterSkillKey { get; set; }
        
        public string CharacterSkillNodeSetKey { get; set; }
        
        public int Indent { get; set; }
        
        public int Tier { get; set; }
        
        public bool VisibleInUi { get; set; }

        //TODO: figure out how to implement this
        public IEnumerable<NodeLink> NodeLinks { get; set; }

        public Skill Skill { get; set; }
    }
}
