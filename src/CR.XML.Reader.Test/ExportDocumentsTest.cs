using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CR.XML.Reader.Test;

public class ExportDocumentsTest
{
    [Fact]
    public void Export_Excel_Emission_Test()
    {
        ServiceProvider serviceProvider = CreateServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var bl = scope.ServiceProvider.GetRequiredService<IExportDocumentsBL>();

            var data = bl.Export("112770761", new DateTime(2022, 01, 01), new DateTime(2022, 01, 01), Entities.DocModeEnum.Emission);

            Assert.NotNull(data);
        }
    }

    [Fact]
    public void Export_Excel_Reception_Test()
    {
        ServiceProvider serviceProvider = CreateServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var bl = scope.ServiceProvider.GetRequiredService<IExportDocumentsBL>();

            var data = bl.Export("112770761", new DateTime(2022, 01, 01), new DateTime(2022, 01, 01), Entities.DocModeEnum.Reception);

            Assert.NotNull(data);
        }
    }

    private ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddLogging(l => l.AddFluentMigratorConsole());
        services.AddScoped<IExportDocumentsBL,ExportDocumentsBL>();
        services.AddScoped<IExportRepository, FakeExportRepository>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}
