using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class Skill
    {
        public string Key { get; set; }
        
        public string Name { get; set; }
        
        public int UnlockedAtRank { get; set; }
        
        public string Description { get; set; }
        
        public string ImagePath { get; set; }

        public IEnumerable<LevelToEffect> LevelsToEffects { get; set; }

        public LevelDetail LevelDetail { get; set; }
    }
}
