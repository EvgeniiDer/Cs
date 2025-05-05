using Microsoft.Extensions.Logging;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using DataAccess;
using DataBaseConnector;
using DataSetCache;
namespace DataCacheManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            
            //ServiceCollection
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
        /*private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(ConfigureLogging);
            //Register dependencies

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IConnector, Connector>();
            services.AddTransient<IDataBase, DataBase>();
            services.AddSingleton<IDataCache, DataCache>(provider =>
            {
                var dataBase = provider.GetRequiredService<IDataBase>();
                var logger = provider.GetService<ILogger<DataCache>>();
                return new DataCache(dataBase, 5, logger); // 5 is the refresh interval in minutes
            });

            // Register MainForm
            services.AddTransient<MainForm>();

        }
        private static void ConfigureLogging(ILoggingBuilder builder)
        {
            builder.AddConsole();
            builder.AddDebug();


            
            
    builder.AddConsole(): Этот вызов добавляет провайдер логирования для вывода логов в консоль. Это полезно для отладки и мониторинга во время разработки.
    builder.AddDebug(): Этот вызов добавляет провайдер для вывода логов в окно отладки (Debug Output Window) в Visual Studio. Это также удобно для отладки, так как позволяет видеть логи, не выводя их в консоль.
            
        }*/
    }
}