using System;
using System.Globalization;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
namespace MaterialDesignApp
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfigurationRoot Configuration { get; private set; }

        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UISettings.LoadDesignSettings();
        }
    }
}
