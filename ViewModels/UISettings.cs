using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MaterialDesignApp.ViewModels
{
    

    public class DesignSettings
    {
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
    }

    public static class UISettings
    {
        public static void LoadDesignSettings()
        {
            string jsonPath = "Config/design-settings.json";
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                var settings = JsonConvert.DeserializeObject<DesignSettings>(json);

                // Appliquer les nouvelles couleurs dans les ressources WPF
                Application.Current.Resources["PrimaryBrush"] =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString(settings.PrimaryColor));
                Application.Current.Resources["SecondaryBrush"] =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString(settings.SecondaryColor));
            }
        }
    }

}
