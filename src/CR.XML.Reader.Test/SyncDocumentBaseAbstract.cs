using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using CR.XML.Reader.DB;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using CR.XML.Reader.Entities.XSD.v43.FacturaCompra;
using CR.XML.Reader.Entities.XSD.v43.FacturaExportacion;
using CR.XML.Reader.Entities.XSD.v43.NotaCredito;
using CR.XML.Reader.Entities.XSD.v43.NotaDebito;
using CR.XML.Reader.Entities.XSD.v43.Tiquete;
using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;
using Xunit.Abstractions;

namespace CR.XML.Reader.Test
{
    public abstract class SyncDocumentBaseAbstract
    {
        public SyncDocumentBaseAbstract(ITestOutputHelper helper)
        {
            this.OutputHelper = helper;
            this.dbName = $"{Guid.NewGuid()}";
        }

        #region Atributes
        private string dbName { get; }

        private ITestOutputHelper OutputHelper { get; }
        #endregion

        public ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddScoped<IParseDocumentBL, ParseDocumentBL>();
            services.AddScoped<ISyncDocumentBL, SyncDocumentBL>();

            services.AddScoped<IRepository<FacturaElectronica>, InvoiceRepository>();
            services.AddScoped<IRepository<TiqueteElectronico>, TiquetRepository>();
            services.AddScoped<IRepository<NotaCreditoElectronica>, CreditMemoRepository>();
            services.AddScoped<IRepository<NotaDebitoElectronica>, DebitMemoRepository>();
            services.AddScoped<IRepository<FacturaElectronicaExportacion>, ExportInvoiceRepository>();
            services.AddScoped<IRepository<FacturaElectronicaCompra>, PurchaseInvoiceRepository>();

            services.AddLogging((builder) => builder.AddXUnit(OutputHelper));

            var db = Guid.NewGuid().ToString();
            services.AddLogging(l => l.AddFluentMigratorConsole()).
                AddFluentMigratorCore().ConfigureRunner(r =>
                r.AddSQLite()
                .WithGlobalConnectionString($"Data Source={this.dbName}; Mode = Memory; Cache = Shared")
                .ScanIn(typeof(_0001_Add_Invoice_Tables).Assembly).For.Migrations()
            );

            services.AddScoped<IDbConnection>((op) =>
            {
                return new SqliteConnection($"Data Source={this.dbName};Mode = Memory; Cache = Shared");
            });

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
