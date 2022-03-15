using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CR.XML.Reader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var frmMain = serviceProvider.GetRequiredService<frmMain>();
                Application.Run(frmMain);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<frmMain>();
            services.AddScoped<IParseDocumentBL, ParseDocumentBL>();
            services.AddScoped<IDbConnection>((op) =>
            {
                // TODO: Remove hardcoded.
                return new SqliteConnection(@"Data Source=D:\Temp\InvoicesCR.db");
            });
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        }
    }
}