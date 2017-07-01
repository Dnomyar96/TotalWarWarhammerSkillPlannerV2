using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TotalWarWarhammerSkillPlannerV2.Views
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : Window
    {
        private string log;
        private string text;
        private bool logShown;

        public Console()
        {
            InitializeComponent();
            logShown = true;
        }

        public void WriteLine(string txt = "")
        {
            if (!logShown)
            {
                textBlock.Text += txt + Environment.NewLine;
                scroller.ScrollToEnd();
            }
            else
            {
                text += txt + Environment.NewLine;
            }
        }

        public void Log(string lg = "")
        {
            if (logShown)
            {
                textBlock.Text += lg + Environment.NewLine;
                scroller.ScrollToEnd();
            }
            else
            {
                log += lg + Environment.NewLine;
            }
        }

        public void Clear()
        {
            textBlock.Text = "";
        }

        public void ShowLog()
        {
            if(!logShown)
            {
                text = textBlock.Text;
            }
            else
            {
                log = textBlock.Text;
            }

            textBlock.Text = log;
            logShown = true;
        }

        public void ShowText()
        {
            if (!logShown)
            {
                text = textBlock.Text;
            }
            else
            {
                log = textBlock.Text;
            }

            textBlock.Text = text;
            logShown = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowLog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowText();
        }
    }
}
