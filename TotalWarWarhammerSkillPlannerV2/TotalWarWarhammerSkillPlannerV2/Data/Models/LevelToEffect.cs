using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class LevelToEffect
    {
        public string SkillKey { get; set; }

        public string EffectKey { get; set; }

        public string EffectScope { get; set; }

        public bool IsFactionwide { get; set; }

        public int Level { get; set; }

        public int Value { get; set; }

        public Effect Effect { get; set; }
    }
}
