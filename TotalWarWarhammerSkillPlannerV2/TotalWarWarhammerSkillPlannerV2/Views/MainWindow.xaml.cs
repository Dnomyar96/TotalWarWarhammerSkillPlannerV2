using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using TotalWarWarhammerSkillPlannerV2.Data.Models;

namespace TotalWarWarhammerSkillPlannerV2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void skillsBtn_Click(object sender, RoutedEventArgs e)
        {
            var serialzer = new XmlSerializer(typeof(SkillCollection));

            using (var fs = new FileStream(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\character_skills.xml", FileMode.Open))
            {
                var skills = (SkillCollection)serialzer.Deserialize(fs);
                gridBox.ItemsSource = skills.Skills;
            }
        }

        private void nodesBtn_Click(object sender, RoutedEventArgs e)
        {
            var serialzer = new XmlSerializer(typeof(SkillNodesCollection));

            using (var fs = new FileStream(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\character_skill_nodes.xml", FileMode.Open))
            {
                var skills = (SkillNodesCollection)serialzer.Deserialize(fs);
                gridBox.ItemsSource = skills.SkillNodes;
            }
        }

        private void Links_Click(object sender, RoutedEventArgs e)
        {
            var serialzer = new XmlSerializer(typeof(SkillNodeLinksCollection));

            using (var fs = new FileStream(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\character_skill_node_links.xml", FileMode.Open))
            {
                var skills = (SkillNodeLinksCollection)serialzer.Deserialize(fs);
                gridBox.ItemsSource = skills.SkillNodeLinks;
            }
        }

        private void levelDetails_Click(object sender, RoutedEventArgs e)
        {
            var serialzer = new XmlSerializer(typeof(SkillLevelDetailsCollection));

            using (var fs = new FileStream(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\character_skill_level_details.xml", FileMode.Open))
            {
                var skills = (SkillLevelDetailsCollection)serialzer.Deserialize(fs);
                gridBox.ItemsSource = skills.SkillLevelDetails;
            }
        }

        private void levelToEffect_Click(object sender, RoutedEventArgs e)
        {
            var serialzer = new XmlSerializer(typeof(SkillLevelToEffectsCollection));

            using (var fs = new FileStream(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\character_skill_level_to_effects_junctions.xml", FileMode.Open))
            {
                var skills = (SkillLevelToEffectsCollection)serialzer.Deserialize(fs);
                gridBox.ItemsSource = skills.SkillLevelToEffects;
            }
        }

        private void nodeSets_Click(object sender, RoutedEventArgs e)
        {
            var serialzer = new XmlSerializer(typeof(SkillNodeSetsCollection));

            using (var fs = new FileStream(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\character_skill_node_sets.xml", FileMode.Open))
            {
                var skills = (SkillNodeSetsCollection)serialzer.Deserialize(fs);
                gridBox.ItemsSource = skills.SkillNodeSets;
            }
        }

        private void agentSubtypes_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = skills.AgentSubTypes;
        }
    }
}
