
using System.IO;
namespace ADO.NET_WinForm_BD_2._2;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Xml.Linq;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    public static IConfiguration Configuration { get; private set; }
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.


        IConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
        


    }
}