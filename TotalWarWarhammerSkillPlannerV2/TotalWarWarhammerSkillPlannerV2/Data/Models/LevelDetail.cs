﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWarWarhammerSkillPlannerV2.Data.Models
{
    public class LevelDetail
    {
        public string SkillKey { get; set; }

        public int UnlockedAtRank { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
