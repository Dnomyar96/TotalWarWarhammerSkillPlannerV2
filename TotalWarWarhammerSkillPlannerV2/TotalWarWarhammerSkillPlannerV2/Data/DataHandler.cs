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

        private static List<T> GetData<T, C>(string f)
        {
            var serializer = new XmlSerializer(typeof(C));

            using (var fs = new FileStream(basePath.TrimEnd('\\') + "\\" + f, FileMode.Open))
            {
                dynamic r = (C)serializer.Deserialize(fs);
                return r.Collection;
            }
        }

        public static List<AgentSubtype> CreateDataObjects()
        {
            var agents = GetAgentSubTypes();
            var effects = GetEffects();
            var skills = GetSkills();
            var levelDetails = GetSkillLevelDetails();
            var levelToEffects = GetSkillLevelToEffects();
            var nodes = GetSkillNodes();
            var nodeLinks = GetSkillNodeLinks();
            var nodeSets = GetSkillNodeSets();

            var data = new List<AgentSubtype>();

            foreach(var agent in agents)
            {
                var newAgent = new AgentSubtype
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
                    NodeSet = nodeSets.Where(ns => ns.AgentSubtypeKey == agent.Key).Select(ns => new NodeSet
                    {
                        AgentKey = ns.AgentKey,
                        AgentSubtypeKey = ns.AgentSubtypeKey,
                        EncTitle = ns.EncTitle,
                        Key = ns.Key,
                        Nodes = nodes.Where(n => n.CharacterSkillNodeSetKey == ns.Key).Select(n => new Node
                        {
                            CharacterSkillKey = n.CharacterSkillKey,
                            CharacterSkillNodeSetKey = n.CharacterSkillNodeSetKey,
                            Indent = n.Indent,
                            Key = n.Key,
                            Tier = n.Tier,
                            VisibleInUi = n.VisibleInUi,
                            NodeLinks = nodeLinks.Where(nl => nl.ChildKey == n.Key).Select(nl => new NodeLink
                            {
                                ChildKey = nl.ChildKey,
                                LinkType = nl.LinkType,
                                ParentKey = nl.ParentKey
                            }),
                            Skill = skills.Where(s => s.Key == n.CharacterSkillKey).Select(s => new Models.Skill
                            {
                                Description = s.Description,
                                ImagePath = s.ImagePath,
                                Key = s.Key,
                                Name = s.Name,
                                UnlockedAtRank = s.UnlockedAtRank,
                                LevelDetail = levelDetails.Where(l => l.SkillKey == s.Key).Select(l => new LevelDetail
                                {
                                    Description = l.Description,
                                    Name = l.Name,
                                    SkillKey = l.SkillKey,
                                    UnlockedAtRank = l.UnlockedAtRank
                                }).FirstOrDefault(),
                                LevelsToEffects = levelToEffects.Where(l => l.SkillKey == s.Key).Select(l => new LevelToEffect
                                {
                                    EffectKey = l.EffectKey,
                                    EffectScope = l.EffectScope,
                                    IsFactionwide = l.IsFactionwide,
                                    Level = l.Level,
                                    SkillKey = l.SkillKey,
                                    Value = l.Value,
                                    Effect = effects.Where(e => e.Effect == l.EffectKey).Select(e => new Effect
                                    {
                                        Category = e.Category,
                                        Description = e.Description,
                                        Icon = e.Icon,
                                        IconNegative = e.IconNegative,
                                        IsPositiveValueGood = e.IsPositiveValueGood,
                                        Key = e.Effect,
                                        Priority = e.Priority
                                    }).FirstOrDefault()
                                })
                            }).FirstOrDefault()
                        })
                    }).FirstOrDefault()
                };

                data.Add(newAgent);
            }

            return data;
        }
    }
}
