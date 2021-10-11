using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using Telegram.Bot;

namespace HomeWork10
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new TelegramClient(this);
            listBox.ItemsSource = client.BotMessage;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                client.SendMessage(textBox.Text, textBox1.Text);
            }
        }

        private void ShowFiles_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            DirectoryInfo folder = new DirectoryInfo(@"C:\Users\Екатерина\Downloads");
            foreach (FileInfo file in folder.GetFiles())
            {
                window1.listBox.Items.Add(file.Name);               
            }
        }

        private void SaveDialog_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText("Chat.json");
            json = JsonConvert.SerializeObject(listBox);
            File.WriteAllText("Chat.json", json);
        }

        private void ShowWeather_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + "Pechora, RU" + "&appid=" + "8a424f124eedd1c859d12e03fff36147";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
            string response;
            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }
            WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(response);
            window2.listbox.ItemsSource = new[] { new { Temp = weather.Main.Temp - 273 } };
        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
