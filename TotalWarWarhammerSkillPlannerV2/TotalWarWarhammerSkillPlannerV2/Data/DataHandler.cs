using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization;

namespace TotalWarWarhammerSkillPlannerV2.Data
{
    public static class DataHandler
    {
        private static string basePath;

        public static void SetBasePath(string path)
        {
            basePath = path;
        }

        public static List<AgentSubType> GetAgentSubTypes()
        {
            return GetData<AgentSubType, AgentSubTypesCollection>("agent_subtypes.xml");
        }

        public static List<Skill> GetSkills()
        {
            return GetData<Skill, SkillCollection>("character_skills.xml");
        }

        public static List<SkillLevelDetails> GetSkillLevelDetails()
        {
            return GetData<SkillLevelDetails, SkillLevelDetailsCollection>("character_skill_level_details.xml");
        }

        public static List<SkillLevelToEffects> GetSkillLevelToEffects()
        {
            return GetData<SkillLevelToEffects, SkillLevelToEffectsCollection>("character_skill_level_to_effects_junctions.xml");
        }

        public static List<SkillNode> GetSkillNodes()
        {
            return GetData<SkillNode, SkillNodesCollection>("character_skill_nodes.xml");
        }

        public static List<SkillNodeLink> GetSkillNodeLinks()
        {
            return GetData<SkillNodeLink, SkillNodeLinksCollection>("character_skill_node_links.xml");
        }

        public static List<SkillNodeSet> GetSkillNodeSets()
        {
            return GetData<SkillNodeSet, SkillNodeSetsCollection>("character_skill_node_sets.xml");
        }

        public static List<Effects> GetEffects()
        {
            return GetData<Effects, EffectsCollection>("effects.xml");
        }

        private static List<T> GetData<T, C>(string f)
        {
            var serializer = new XmlSerializer(typeof(C));

            using (var fs = new FileStream(basePath.TrimEnd('\\') + "\\" + f, FileMode.Open))
            {
                dynamic r = (C)serializer.Deserialize(fs);
                return r.Collection;
            }
        }
    }
}
