﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Newtonsoft.Json;
using ControlzEx;
using QRCoder;

namespace MaterialDesignApp
{
    public static class UISettings
    {
        public static void LoadDesignSettings()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "design-settings.json");

            MessageBox.Show("📌 Répertoire courant : " + AppDomain.CurrentDomain.BaseDirectory);

            if (!File.Exists(jsonPath))
            {
                MessageBox.Show($"🚫 Fichier JSON introuvable : {jsonPath}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string json = File.ReadAllText(jsonPath);
                if (string.IsNullOrWhiteSpace(json))
                {
                    MessageBox.Show("❌ Le fichier JSON est vide !");
                    return;
                }

                var settings = JsonConvert.DeserializeObject<DesignSettings>(json);

                if (settings == null)
                {
                    MessageBox.Show("⚠️ Erreur lors de la désérialisation !");
                    return;
                }

                // Application des couleurs
                SetResource("PrimaryColor", settings.PrimaryColor);
                SetResource("CalendarForegroundColor", settings.CalendarForegroundColor);
                SetResource("CalendarBorderColor", settings.CalendarBorderColor);
                SetResource("DatePickerForeground", settings.DatePickerForeground);
                SetResource("DatePickerBackground", settings.DatePickerBackground);

                // Taille des polices
                Application.Current.Resources["FontSize"] = ConvertToDouble(settings.FontSize, 14.0);

                // Date Début & Fin
                Application.Current.Resources["DatePickerStartDate"] = ConvertToDate(settings.DatePickerStartDate);
                Application.Current.Resources["DatePickerEndDate"] = ConvertToDate(settings.DatePickerEndDate);

                MessageBox.Show("🎯 Paramètres appliqués avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors du chargement : {ex.Message}");
            }
        }

        private static void SetResource(string resourceKey, string colorValue)
        {
            if (!string.IsNullOrWhiteSpace(colorValue))
            {
                var color = ConvertToColor(colorValue);
                Application.Current.Resources[resourceKey] = new SolidColorBrush(color);
                MessageBox.Show($"🎨 {resourceKey} = {colorValue}");
            }
        }

        private static Color ConvertToColor(string colorString)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(colorString) && colorString.StartsWith("#"))
                {
                    return (Color)ColorConverter.ConvertFromString(colorString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de conversion couleur: {colorString}\n{ex.Message}");
            }

            return Colors.White;
        }

        private static double ConvertToDouble(string value, double defaultValue)
        {
            return double.TryParse(value, out double result) ? result : defaultValue;
        }

        private static DateTime? ConvertToDate(string value)
        {
            return DateTime.TryParse(value, out DateTime result) ? result : (DateTime?)null;
        }

        public static void ReloadMaterialTheme(string theme)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            var themeUri = theme == "Dark"
                ? "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml"
                : "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml";

            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(themeUri)
            });

            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignColors.xaml")
            });

            MessageBox.Show($"🔄 Thème {theme} appliqué !");
        }
    }

    public class DesignSettings
    {
        public string PrimaryColor { get; set; }
        public string CalendarForegroundColor { get; set; }
        public string CalendarBorderColor { get; set; }
        public string DatePickerForeground { get; set; }
        public string DatePickerBackground { get; set; }
        public string FontSize { get; set; }
        public string DatePickerStartDate { get; set; }
        public string DatePickerEndDate { get; set; }
    }
}
