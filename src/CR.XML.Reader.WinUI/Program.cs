using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using CR.XML.Reader.Entities.XSD.v43.FacturaCompra;
using CR.XML.Reader.Entities.XSD.v43.FacturaExportacion;
using CR.XML.Reader.Entities.XSD.v43.NotaCredito;
using CR.XML.Reader.Entities.XSD.v43.NotaDebito;
using CR.XML.Reader.Entities.XSD.v43.Tiquete;
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
            services.AddScoped<ISyncDocumentBL, SyncDocumentBL>();

            // Repos for earch document type
            services.AddScoped<IRepository<FacturaElectronica>, InvoiceRepository>();
            services.AddScoped<IRepository<TiqueteElectronico>, TiquetRepository>();
            services.AddScoped<IRepository<NotaCreditoElectronica>, CreditMemoRepository>();
            services.AddScoped<IRepository<NotaDebitoElectronica>, DebitMemoRepository>();
            services.AddScoped<IRepository<FacturaElectronicaExportacion>, ExportInvoiceRepository>();
            services.AddScoped<IRepository<FacturaElectronicaCompra>, PurchaseInvoiceRepository>();

            services.AddScoped<IDbConnection>((op) =>
            {
                // TODO: Remove hardcoded.
                return new SqliteConnection(@"Data Source=D:\Temp\InvoicesCR.db");
            });
        }
    }
}