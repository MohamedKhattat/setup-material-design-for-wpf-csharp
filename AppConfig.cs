using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
namespace MaterialDesignApp
{
    public static class AppConfig
    {
        public static IConfigurationRoot Configuration { get; private set; }
         static AppConfig()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static string GetPrimaryColor() => Configuration["UISettings:PrimaryColor"];
    public static string GetSecondaryColor() => Configuration["UISettings:SecondaryColor"];
    public static string GetFontFamily() => Configuration["UISettings:FontFamily"];
    public static int GetFontSize() => int.Parse(Configuration["UISettings:FontSize"]);
    }
}
