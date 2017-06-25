using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class Effect
    {
        public string Key { get; set; }

        public string Category { get; set; }
        
        public string Description { get; set; }
        
        public bool IsPositiveValueGood { get; set; }
        
        public int Priority { get; set; }

        public string Icon { get; set; }

        public string IconNegative { get; set; }
    }
}
