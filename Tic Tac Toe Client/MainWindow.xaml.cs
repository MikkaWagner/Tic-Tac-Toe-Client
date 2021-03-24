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
using Newtonsoft.Json;

namespace Tic_Tac_Toe_Client
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connection connection;
        public bool connected = false;
        public static bool wInput = false;
        string x = "X";

        public static MainWindow window { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            window = this;

        }
        
        private void bttn_1_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_1.Content.Equals("")) {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "1");
                        changeIcon(1, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_2_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_2.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "2");
                        changeIcon(2, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_3_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_3.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "3");
                        changeIcon(3, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_4_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_4.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "4");
                        changeIcon(4, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_5_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_5.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "5");
                        changeIcon(5, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_6_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_6.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "6");
                        changeIcon(6, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_7_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_7.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "7");
                        changeIcon(7, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_8_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_8.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "8");
                        changeIcon(8, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }

        private void bttn_9_Click(object sender, RoutedEventArgs e)
        {
            if (bttn_9.Content.Equals(""))
            {
                if (wInput)
                    try
                    {
                        connection.SendMessage("bgact", "9");
                        changeIcon(9, x);
                        wInput = false;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to send package");
                    }
            }
        }
    

        private void bttn_settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsw = new SettingsWindow();
            settingsw.Show();
        }

        private void bttn_connect_Click(object sender, RoutedEventArgs e)
        {
            if (!connected)
            {
                string settjson = File.ReadAllText("settings.json");
                var settings = JsonConvert.DeserializeObject<dynamic>(settjson);
                string ip = settings.ip;
                int port = Convert.ToInt32(settings.port);
                string name = settings.name;
                try
                {
                    connected = true;
                    connection = new Connection(ip, port);
                    connection.SendMessage("name", name);
                    bttn_connect.Content = "Disconnect";
                }
                catch
                {
                    MessageBox.Show("Can't connect to server");
                }
            }
            else
            {
                connected = false;
                connection.Disconnect();
                bttn_connect.Content = "Connect";
            }

            
        }
        public void process(string jsonString)
        {
            try
            {
                if (jsonString == null) return;
                var data = JsonConvert.DeserializeObject<dynamic>(jsonString);

                string type = (string)data.type;
                switch (type)
                {
                    case "log":
                        
                            Console.WriteLine("--Server-type--> " + data.type);
                            Console.WriteLine("--Server-value--> " + data.value);
                            string value1 = data.value;
                            log(value1);
                            break;
                        

                    case "err":
                        
                            Console.WriteLine("--Server-type--> " + data.type);
                            Console.WriteLine("--Server-value--> " + data.value);
                            string value2 = data.value;
                            //err(value2);
                            break;
                        

                    case "gact":
                        
                        Console.WriteLine("--Server-type--> " + data.type);
                        Console.WriteLine("--Server-value--> " + data.value);
                    string value3 = data.value;
                        gact(value3);
                        break;

                    case "bgact":
                        Console.WriteLine("--Server-type--> " + data.type);
                        Console.WriteLine("--Server-value--> " + data.value);
                        string value4 = data.value;
                        changeIcon(Convert.ToInt32(value4), "O");
                        break;

                    case "enemy":
                        Console.WriteLine("--Server-type--> " + data.type);
                        Console.WriteLine("--Server-value--> " + data.value);
                        string value5 = data.value;
                        //enemy(value5);
                        break;

                    case "ping":
                        Console.WriteLine("--Server-type--> " + data.type);
                        Console.WriteLine("--Server-value--> " + data.value);
                        string value6 = data.value;
                        //ping(value6);
                        break;

                    default:
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Wrong type!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Wrong message");
            }

            //Dispatcher.Invoke(() =>
            //{

            //});
        }

        public void gact(string value)
        {
            if (value.Equals("winput"))
            {
                wInput = true;
            }
        }
        public void changeIcon(int i, string s)
        {
            Dispatcher.Invoke(() =>
            {


                switch (i)
                {
                    case 1:
                        bttn_1.Content = s;
                        break;
                    case 2:
                        bttn_2.Content = s;
                        break;
                    case 3:
                        bttn_3.Content = s;
                        break;
                    case 4:
                        bttn_4.Content = s;
                        break;
                    case 5:
                        bttn_5.Content = s;
                        break;
                    case 6:
                        bttn_6.Content = s;
                        break;
                    case 7:
                        bttn_7.Content = s;
                        break;
                    case 8:
                        bttn_8.Content = s;
                        break;
                    case 9:
                        bttn_9.Content = s;
                        break;
                }
            });
        }
        public void log(string value)
        {
            Dispatcher.Invoke(() =>
            {
                switch (value)
                {
                    case "ok":
                        break;
                    case "waiting":
                        lbl_info.Content = "Waiting for player";
                        Console.WriteLine("Waiting for player");
                        break;
                    case "gstart":
                        lbl_info.Content = "Game started";
                        Console.WriteLine("Game started");
                        break;
                    case "":
                        break;

                }


            });
        }


    }
}
