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
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Tic_Tac_Toe_Client
{
    /// <summary>
    /// Interaktionslogik für SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            string settjson = File.ReadAllText("settings.json");
            var settings = JsonConvert.DeserializeObject<dynamic>(settjson);
            txtbox_ip.Text = settings.ip;
            txtbox_port.Text = settings.port;
            txtbox_name.Text = settings.name;
            Console.WriteLine(settjson);
        }

        private void bttn_savesettings_Click(object sender, RoutedEventArgs e)
        {
            Settings newsett = new Settings();
            newsett.ip = txtbox_ip.Text;
            newsett.port = txtbox_port.Text;
            newsett.name = txtbox_name.Text;
            string output = JsonConvert.SerializeObject(newsett);
            File.WriteAllText("settings.json", output);
            Close();
        }

    }

    class Settings
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string name { get; set; }
    }
}
