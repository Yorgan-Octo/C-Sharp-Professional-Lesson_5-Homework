using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace Task_4
{

    public enum ColorsApplication
    {
        White,
        Black,
        Azure,
        Blue,
        Aqua,
        Beige,
        Red,
        DarkBlue,
        DarkGray,
        Gray
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var config = new ConfigurationBuilder().AddJsonFile("settings.json").Build();

            for (int i = 0; i <= 7; i++)
            {
                ColorBoxBG.Items.Add(Convert.ToString((ColorsApplication)i));
                ColorBoxFC.Items.Add(Convert.ToString((ColorsApplication)i));
            }

            ColorBoxBG.SelectedItem = config["Application:BackgroundColor"];
            ColorBoxFC.SelectedItem = config["Application:ForegroundColor"];

            Background = new BrushConverter().ConvertFromString(config["Application:BackgroundColor"]) as Brush;
            Foreground = new BrushConverter().ConvertFromString(config["Application:ForegroundColor"]) as Brush;

        }

        private void ApplyButt_Click(object sender, RoutedEventArgs e)
        {
            string colorxBG = ColorBoxBG.Text;
            string colorxFC = ColorBoxFC.Text;

            Brush brush = new BrushConverter().ConvertFromString(colorxBG) as Brush;
            Background = brush;

            brush = new BrushConverter().ConvertFromString(colorxFC) as Brush;
            Foreground = brush;


        }

        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {

            var json = new JObject
            {
                ["Application"] = new JObject
                {
                    ["BackgroundColor"] = ColorBoxBG.Text,
                    ["ForegroundColor"] = ColorBoxFC.Text
                }
            };

            // Сохранение JSON в файл
            File.WriteAllText("settings.json", json.ToString());

        }
    }
}
