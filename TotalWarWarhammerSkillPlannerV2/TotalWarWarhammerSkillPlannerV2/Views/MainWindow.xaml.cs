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
using TotalWarWarhammerSkillPlannerV2.Data;
using TotalWarWarhammerSkillPlannerV2.Data.Models.Serialization;

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
            DataHandler.SetBasePath(@"E:\Steam\steamapps\common\Total War WARHAMMER\assembly_kit\raw_data\db\");
        }

        private void skillsBtn_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetSkills();
        }

        private void nodesBtn_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetSkillNodes();
        }

        private void Links_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetSkillNodeLinks();
        }

        private void levelDetails_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetSkillLevelDetails();
        }

        private void levelToEffect_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetSkillLevelToEffects();
        }

        private void nodeSets_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetSkillNodeSets();
        }

        private void agentSubtypes_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetAgentSubTypes();
        }

        private void effectsBtn_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.GetEffects();
        }

        private void objectBtn_Click(object sender, RoutedEventArgs e)
        {
            gridBox.ItemsSource = DataHandler.CreateDataObjects();
        }
    }
}
