using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using CR.XML.Reader.DB;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using CR.XML.Reader.Entities.XSD.v43.FacturaCompra;
using CR.XML.Reader.Entities.XSD.v43.FacturaExportacion;
using CR.XML.Reader.Entities.XSD.v43.NotaCredito;
using CR.XML.Reader.Entities.XSD.v43.NotaDebito;
using CR.XML.Reader.Entities.XSD.v43.Tiquete;
using FluentMigrator.Runner;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;
using NLog.Extensions.Logging;
using CR.XML.Reader.WinUI;

namespace CR.XML.Reader
{
    internal static class Program
    {
        #region Contants
        // TODO : Read from Config.
        private const string DBPath = @".\db\InvoicesCR.db";
        private const string ConnectionString = @"Data Source={0}";
        #endregion

        #region Public Static
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();

                var frm = new frmMain(serviceProvider);
                Application.Run(frm);
            }
        }
        #endregion

        #region Private Static
        private static void ConfigureServices(ServiceCollection services)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            services.AddScoped<frmMain>();
            services.AddScoped<frmSyncFolder>();
            services.AddScoped<IParseDocumentBL, ParseDocumentBL>();
            services.AddScoped<ISyncDocumentBL, SyncDocumentBL>();
            services.AddScoped<GeneralInfoRepository>();

            // Repos for earch document type
            services.AddScoped<IRepository<FacturaElectronica>, InvoiceRepository>();
            services.AddScoped<IRepository<TiqueteElectronico>, TiquetRepository>();
            services.AddScoped<IRepository<NotaCreditoElectronica>, CreditMemoRepository>();
            services.AddScoped<IRepository<NotaDebitoElectronica>, DebitMemoRepository>();
            services.AddScoped<IRepository<FacturaElectronicaExportacion>, ExportInvoiceRepository>();
            services.AddScoped<IRepository<FacturaElectronicaCompra>, PurchaseInvoiceRepository>();

            services.AddScoped<IDbConnection>((op) =>
            {
                return new SqliteConnection(string.Format(ConnectionString, DBPath));
            });

            services.AddFluentMigratorCore().ConfigureRunner(r =>
                r.AddSQLite()
                .WithGlobalConnectionString(string.Format(ConnectionString, DBPath))
                .ScanIn(typeof(_0001_Add_Main_Tables).Assembly).For.Migrations()
            );

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.AddNLog(config);
            });
        }
        #endregion 
    }
}