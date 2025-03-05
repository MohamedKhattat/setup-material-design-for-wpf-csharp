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

        /* protected override void OnStartup(StartupEventArgs e)
         {
             base.OnStartup(e);

             // Charger la configuration depuis appsettings.json
             var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory()) // Définit le chemin du fichier
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             Configuration = builder.Build();

             // Lire la valeur "DatePickerStartDate"
             string dateStr = Configuration["UISettings:DatePickerStartDate"];

             // Convertir la chaîne en DateTime
             if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
             {
                 // Injecter dans Application.Resources
                 Resources["DatePickerStartDate"] = dateValue;
             }
             else
             {
                 // Valeur par défaut en cas d'erreur
                 Resources["DatePickerStartDate"] = new DateTime(1999, 1, 1);
             }
         }
     */
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UISettings.LoadDesignSettings();
        }
    }
}
