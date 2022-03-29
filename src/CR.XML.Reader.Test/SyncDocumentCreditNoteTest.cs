using CR.XML.Reader.BL;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CR.XML.Reader.Test
{
    public class SyncDocumentCreditNoteTest : SyncDocumentBaseAbstract
    {
        public SyncDocumentCreditNoteTest(ITestOutputHelper helper) : base(helper)
        {

        }

        [Fact]
        public void Test_Sync_Valid_CrediNote()
        {
            ServiceProvider serviceProvider = CreateServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();

                var parser = scope.ServiceProvider.GetRequiredService<IParseDocumentBL>();
                var bl = scope.ServiceProvider.GetRequiredService<ISyncDocumentBL>();

                // Act
                var doc = parser.Parse(TestResources.RealNCText);
                bl.SyncDocument(doc);
            }

        }
    }
}
