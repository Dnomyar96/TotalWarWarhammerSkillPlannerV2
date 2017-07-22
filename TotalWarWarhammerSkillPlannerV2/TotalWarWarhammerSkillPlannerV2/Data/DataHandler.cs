using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TotalWarWarhammerSkillPlannerV2.Data.Models;
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

        public static List<Models.Serialization.Skill> GetSkills()
        {
            return GetData<Models.Serialization.Skill, SkillCollection>("character_skills.xml");
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

        public static List<FactionAgentPermittedSubtypes> GetFactionAgentPermittedSubTypes()
        {
            return GetData<FactionAgentPermittedSubtypes, FactionAgentPermittedSubTypeCollection>("faction_agent_permitted_subtypes.xml");
        }

        public static List<Models.Serialization.Faction> GetFactions()
        {
            return GetData<Models.Serialization.Faction, FactionCollection>("factions.xml");
        }

        public static List<FactionToFactionGroups> GetFactionToFactionGroups()
        {
            return GetData<FactionToFactionGroups, FactionToFactionGroupsCollection>("faction_to_faction_groups_junctions.xml");
        }

        public static List<FactionGroups> GetFactionGroups()
        {
            return GetData<FactionGroups, FactionGroupsCollection>("faction_groups.xml");
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

        private static AgentSubtype CreateAgentSubType(this AgentSubType agent)
        {
            var factionKeys = DataObjects.PermittedSubtypes.Where(ps => ps.AgentSubType == agent.Key).Select(ps => ps.Faction);

            var data = new AgentSubtype
            {
                AssociatedUnitOverride = agent.AssociatedUnitOverride,
                AutoGenerate = agent.AutoGenerate,
                DescriptionTextOverride = agent.DescriptionTextOverride,
                HasFemaleName = agent.HasFemaleName,
                IsCaster = agent.IsCaster,
                Key = agent.Key,
                OnscreenNameOverride = agent.OnscreenNameOverride,
                ShowInUi = agent.ShowInUi,
                SmallIcon = agent.SmallIcon,
                NodeSet = DataObjects.NodeSets.Where(ns => ns.AgentSubtypeKey == agent.Key).Select(ns => ns.CreateNodeSet()).FirstOrDefault(),
                Factions = DataObjects.Factions.Where(f => factionKeys.Contains(f.Key)).Select(f => f.CreateFaction()).ToList()
            };

            return data;
        }

        private static Effect CreateEffect(this Effects effect)
        {
            var data = new Effect
            {
                Category = effect.Category,
                Description = effect.Description,
                Icon = effect.Icon,
                IconNegative = effect.IconNegative,
                IsPositiveValueGood = effect.IsPositiveValueGood,
                Key = effect.Effect,
                Priority = effect.Priority
            };

            return data;
        }

        private static Models.Skill CreateSkill(this Models.Serialization.Skill skill)
        {
            var data = new Models.Skill
            {
                Description = skill.Description,
                ImagePath = skill.ImagePath,
                Key = skill.Key,
                Name = skill.Name,
                UnlockedAtRank = skill.UnlockedAtRank,
                LevelDetail = DataObjects.LevelDetails.Where(l => l.SkillKey == skill.Key).Select(l => l.CreateLevelDetail()).FirstOrDefault(),
                LevelsToEffects = DataObjects.LevelToEffects.Where(l => l.SkillKey == skill.Key).Select(l => l.CreateLevelToEffect())
            };

            return data;
        }

        private static LevelDetail CreateLevelDetail(this SkillLevelDetails levelDetail)
        {
            var data = new LevelDetail
            {
                Description = levelDetail.Description,
                Name = levelDetail.Name,
                SkillKey = levelDetail.SkillKey,
                UnlockedAtRank = levelDetail.UnlockedAtRank
            };

            return data;
        }

        private static LevelToEffect CreateLevelToEffect(this SkillLevelToEffects levelToEffect)
        {
            var data = new LevelToEffect
            {
                EffectKey = levelToEffect.EffectKey,
                EffectScope = levelToEffect.EffectScope,
                IsFactionwide = levelToEffect.IsFactionwide,
                Level = levelToEffect.Level,
                SkillKey = levelToEffect.SkillKey,
                Value = levelToEffect.Value,
                Effect = DataObjects.Effects.Where(e => e.Effect == levelToEffect.EffectKey).Select(e => e.CreateEffect()).FirstOrDefault()
            };

            return data;
        }

        private static Node CreateNode(this SkillNode node)
        {
            var data = new Node
            {
                CharacterSkillKey = node.CharacterSkillKey,
                CharacterSkillNodeSetKey = node.CharacterSkillNodeSetKey,
                Indent = node.Indent,
                Key = node.Key,
                Tier = node.Tier,
                VisibleInUi = node.VisibleInUi,
                NodeLinks = DataObjects.NodeLinks.Where(nl => nl.ChildKey == node.Key).Select(nl => nl.CreateNodeLink()),
                Skill = DataObjects.Skills.Where(s => s.Key == node.CharacterSkillKey).Select(s => s.CreateSkill()).FirstOrDefault()
            };

            return data;
        }

        private static NodeLink CreateNodeLink(this SkillNodeLink nodeLink)
        {
            var data = new NodeLink
            {
                ChildKey = nodeLink.ChildKey,
                LinkType = nodeLink.LinkType,
                ParentKey = nodeLink.ParentKey
            };

            return data;
        }

        private static NodeSet CreateNodeSet(this SkillNodeSet nodeSet)
        {
            var data = new NodeSet
            {
                AgentKey = nodeSet.AgentKey,
                AgentSubtypeKey = nodeSet.AgentSubtypeKey,
                EncTitle = nodeSet.EncTitle,
                Key = nodeSet.Key,
                Nodes = DataObjects.Nodes.Where(n => n.CharacterSkillNodeSetKey == nodeSet.Key).Select(n => n.CreateNode())
            };

            return data;
        }

        private static Models.Faction CreateFaction(this Models.Serialization.Faction faction)
        {
            var groupKey = DataObjects.FactionToFactionGroups.Where(fg => fg.FactionKey == faction.Key).FirstOrDefault();
            var group = "";

            if (groupKey != null)
                group = DataObjects.FactionGroups.Where(fg => fg.Key == groupKey.FactionGroupKey).FirstOrDefault().Name;

            var data = new Models.Faction
            {
                Key = faction.Key,
                Name = faction.Name,
                Group = group
            };

            return data;
        }

        public static List<AgentSubtype> CreateDataObjects()
        {
            DataObjects.Agents = GetAgentSubTypes();
            DataObjects.Effects = GetEffects();
            DataObjects.Skills = GetSkills();
            DataObjects.LevelDetails = GetSkillLevelDetails();
            DataObjects.LevelToEffects = GetSkillLevelToEffects();
            DataObjects.Nodes = GetSkillNodes();
            DataObjects.NodeLinks = GetSkillNodeLinks();
            DataObjects.NodeSets = GetSkillNodeSets();
            DataObjects.PermittedSubtypes = GetFactionAgentPermittedSubTypes();
            DataObjects.Factions = GetFactions();
            DataObjects.FactionToFactionGroups = GetFactionToFactionGroups();
            DataObjects.FactionGroups = GetFactionGroups();

            var data = new List<AgentSubtype>();

            foreach (var agent in DataObjects.Agents)
            {
                var newAgent = agent.CreateAgentSubType();

                data.Add(newAgent);
            }

            return data;
        }

        private static class DataObjects
        {
            public static List<AgentSubType> Agents { get; set; }

            public static List<Effects> Effects { get; set; }

            public static List<Models.Serialization.Skill> Skills { get; set; }

            public static List<SkillLevelDetails> LevelDetails { get; set; }

            public static List<SkillLevelToEffects> LevelToEffects { get; set; }

            public static List<SkillNode> Nodes { get; set; }

            public static List<SkillNodeLink> NodeLinks { get; set; }

            public static List<SkillNodeSet> NodeSets { get; set; }

            public static List<FactionAgentPermittedSubtypes> PermittedSubtypes { get; set; }

            public static List<Models.Serialization.Faction> Factions { get; set; }

            public static List<FactionToFactionGroups> FactionToFactionGroups { get; set; }

            public static List<FactionGroups> FactionGroups { get; set; }
        }
    }
}
