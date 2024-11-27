using CR.XML.Reader.BL;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace CR.XML.Reader.Test;

public class SyncDocumentInvoiceTest : SyncDocumentBaseAbstract
{
    public SyncDocumentInvoiceTest(ITestOutputHelper helper) : base(helper)
    {

    }

    [Fact]
    public void Test_Sync_Valid_Invoice()
    {
        ServiceProvider serviceProvider = CreateServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();

            var parser = scope.ServiceProvider.GetRequiredService<IParseDocumentBL>();
            var bl = scope.ServiceProvider.GetRequiredService<ISyncDocumentBL>();

            // Act
            var doc = parser.Parse(TestResources.RealFEText);
            bl.SyncDocument(doc);
        }
    }
}
