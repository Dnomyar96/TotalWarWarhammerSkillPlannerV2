using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TotalWarWarhammerSkillPlannerV2.Data.Models;

namespace TotalWarWarhammerSkillPlannerV2.Data
{
    public static class DataHandler
    {
        private static string basePath;

        private static List<AgentSubType> agentSubTypes;
        private static List<Skill> skills;
        private static List<SkillLevelDetails> skillLevelDetails;
        private static List<SkillLevelToEffects> skilLevelToEffects;
        private static List<SkillNode> skillNodes;
        private static List<SkillNodeLink> skillNodeLinks;
        private static List<SkillNodeSet> skillNodeSets;

        public static void SetBasePath(string path)
        {
            basePath = path;
        }

        public static List<AgentSubType> GetAgentSubTypes()
        {
            return GetData<AgentSubType, AgentSubTypesCollection>(agentSubTypes, "agent_subtypes.xml");
        }
        
        private static List<T> GetData<T, C>(List<T> x, string f)
        {
            if (x != null && x.Count() > 0)
                return x;

            var serializer = new XmlSerializer(typeof(C));

            using (var fs = new FileStream(basePath.TrimEnd('\\') + "\\" + f, FileMode.Open))
            {
                dynamic r = (C)serializer.Deserialize(fs);
                return r.Collection;
            }
        }
    }
}
