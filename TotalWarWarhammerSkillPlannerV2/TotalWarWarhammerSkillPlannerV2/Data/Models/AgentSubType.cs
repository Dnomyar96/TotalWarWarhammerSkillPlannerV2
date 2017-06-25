using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class AgentSubtype
    {
        public string Key { get; set; }
        
        public string OnscreenNameOverride { get; set; }
        
        public string DescriptionTextOverride { get; set; }
        
        public string AssociatedUnitOverride { get; set; }
        
        public bool AutoGenerate { get; set; }
        
        public bool HasFemaleName { get; set; }
        
        public bool IsCaster { get; set; }
        
        public bool ShowInUi { get; set; }
        
        public string SmallIcon { get; set; }

        public NodeSet NodeSet { get; set; }
    }
}
