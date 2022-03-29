using CR.XML.Reader.BL;
using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Xunit;
using Xunit.Abstractions;

namespace CR.XML.Reader.Test
{
    public class SyncDocumentTiquetTest : SyncDocumentBaseAbstract
    {
        #region Constructors
        public SyncDocumentTiquetTest (ITestOutputHelper helper) : base (helper)
        {
        }
        #endregion

        #region Test Methods
        [Fact]
        public void Integral_Test_Sync_Valid_Tiquet_Simple()
        {
            // Arrange
            ServiceProvider serviceProvider = CreateServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();

                var parser = scope.ServiceProvider.GetRequiredService<IParseDocumentBL>();
                var bl = scope.ServiceProvider.GetRequiredService<ISyncDocumentBL>();

                // Act
                var doc = parser.Parse(TestResources.RealTiquetText);
                bl.SyncDocument(doc);

                IDbConnection connection = scope.ServiceProvider.GetRequiredService<IDbConnection>();

                AssertHeader(connection);

                AssertDetail(connection);

                AssertComercialCode(connection);

                AssertTaxes(connection);

                AssertPaymentMethods(connection);

                AssertTotals(connection);
            }
        }
        #endregion

        #region Private Methods
        private static void AssertHeader(IDbConnection connection)
        {
            var tiquetDB = connection.QueryFirstOrDefault<dynamic>("select * from Tiquete");

            // Asserts
            Assert.NotNull(tiquetDB);
            Assert.Equal(tiquetDB.Clave, "50601112000310134740300100005040000105120300105120");
            Assert.Equal(tiquetDB.NumeroConsecutivo, "00100005040000105120");
            Assert.Equal(tiquetDB.CodigoActividad, "523205");
            Assert.Equal(tiquetDB.FechaEmision.ToString(), "2020-11-01 15:34:38");
            Assert.Equal(tiquetDB.EmisorNombre, "VENECORI, S.A.");
            Assert.Equal(tiquetDB.EmisorIdentificacionTipo, "02");
            Assert.Equal(tiquetDB.EmisorIdentificacionNumero, "3101347403");
            Assert.Equal(tiquetDB.EmisorNombreComercial, "ALISS");
            Assert.Equal(tiquetDB.EmisorUbicacionProvincia, "1");
            Assert.Equal(tiquetDB.EmisorUbicacionCanton, "18");
            Assert.Equal(tiquetDB.EmisorUbicacionDistrito, "01");
            Assert.Equal(tiquetDB.EmisorUbicacionBarrio, "09");
            Assert.Equal(tiquetDB.EmisorUbicacionOtrasSenas, "CostadoEste del registro nacional.");
            Assert.Equal(tiquetDB.EmisorTelefonoCodigoPais, "506");
            Assert.Equal(tiquetDB.EmisorTelefonoNumTelefono, "21051600");
            Assert.Equal(tiquetDB.EmisorCorreoElectronico, "facturaelectronica.cr@alissgroup.com");
            Assert.Equal(tiquetDB.ReceptorIdentificacionExtranjero, null);
            Assert.Equal(tiquetDB.ReceptorNombreComercial, null);
            Assert.Equal(tiquetDB.ReceptorUbicacionProvincia, null);
            Assert.Equal(tiquetDB.ReceptorUbicacionCanton, null);
            Assert.Equal(tiquetDB.ReceptorUbicacionDistrito, null);
            Assert.Equal(tiquetDB.ReceptorUbicacionBarrio, null);
            Assert.Equal(tiquetDB.ReceptorUbicacionOtrasSenas, null);
            Assert.Equal(tiquetDB.ReceptorTelefonoCodigoPais, null);
            Assert.Equal(tiquetDB.ReceptorTelefonoNumTelefono, null);
            Assert.Equal(tiquetDB.ReceptorCorreoElectronico, null);
            Assert.Equal(tiquetDB.CondicionVenta, "01");
            Assert.Equal(tiquetDB.PlazoCredito, null);
        }

        private static void AssertDetail(IDbConnection connection)
        {
            var detailDB = connection.Query<dynamic>("select * from TiqueteDetalle");

            Assert.Single(detailDB);

            var row1 = detailDB.First();

            Assert.Equal(row1.Clave, "50601112000310134740300100005040000105120300105120");
            Assert.Equal(row1.NumeroLinea, "1");
            Assert.Equal(row1.Codigo, null);
            Assert.Equal(row1.Cantidad, 1);
            Assert.Equal(row1.UnidadMedida, "Unid");
            Assert.Equal(row1.UnidadMedidaComercial, "UD");
            Assert.Equal(row1.Detalle, "SNOWMAN CUSHION 35.5X35.5CM/14X14IN");
            Assert.Equal(row1.PrecioUnitario, 3938.05);
            Assert.Equal(row1.MontoTotal, 3938.05);
            Assert.Equal(row1.SubTotal, 3938.05);
            Assert.Equal(row1.BaseImponible, 3938.05);
            Assert.Equal(row1.ImpuestoNeto, 0);
            Assert.Equal(row1.MontoTotalLinea, 4449.9965);
        }

        private static void AssertComercialCode (IDbConnection connection)
        {
            var detailDB = connection.Query<dynamic>("select * from TiqueteDetalleCodigoComercial");

            Assert.Single(detailDB);

            var row1 = detailDB.First();
            Assert.Equal(row1.Clave, "50601112000310134740300100005040000105120300105120");
            Assert.Equal(row1.NumeroLinea, "1");
            Assert.Equal(row1.Tipo, "03");
            Assert.Equal(row1.Codigo, "487569");
        }

        private static void AssertTaxes(IDbConnection connection)
        {
            var detailDB = connection.Query<dynamic>("select * from TiqueteImpuesto");

            Assert.Single(detailDB);

            var row1 = detailDB.First();
            Assert.Equal(row1.Clave, "50601112000310134740300100005040000105120300105120");
            Assert.Equal(row1.NumeroLinea, "1");
            Assert.Equal(row1.Codigo, "01");
            Assert.Equal(row1.CodigoTarifa, "08");
            Assert.Equal(row1.Tarifa, 13);
            Assert.Equal(row1.FactorIVA, 0);
            Assert.Equal(row1.Monto, 511.9465);
            Assert.Equal(row1.ExoneracionTipoDocumento, null);
            Assert.Equal(row1.ExoneracionNumeroDocumento, null);
            Assert.Equal(row1.ExoneracionNombreInstitucion, null);
            Assert.Equal(row1.ExoneracionFechaEmision, null);
            Assert.Equal(row1.ExoneracionPorcentaje, null);
            Assert.Equal(row1.ExoneracionMonto, null);
        }

        private static void AssertPaymentMethods(IDbConnection connection)
        {
            var detailDB = connection.Query<dynamic>("select * from TiqueteMedioPago");

            Assert.Single(detailDB);

            var row1 = detailDB.First();
            Assert.Equal(row1.Clave, "50601112000310134740300100005040000105120300105120");
            Assert.Equal(row1.MedioPago, "02");
        }

        private static void AssertTotals(IDbConnection connection)
        {
            var detailDB = connection.Query<dynamic>("select * from TiqueteResumen");

            Assert.Single(detailDB);

            var row1 = detailDB.First();
            Assert.Equal(row1.Clave, "50601112000310134740300100005040000105120300105120");
            Assert.Equal(row1.CodigoTipoMoneda, "CRC");
            Assert.Equal(row1.TipoCambio, 1);
            Assert.Equal(row1.TotalServGravados, 0);
            Assert.Equal(row1.TotalServExentos, 0);
            Assert.Equal(row1.TotalServExonerado, 0);
            Assert.Equal(row1.TotalMercanciasGravadas, 3938.05);
            Assert.Equal(row1.TotalMercanciasExentas, 0);
            Assert.Equal(row1.TotalMercExonerada, 0);
            Assert.Equal(row1.TotalGravado, 3938.05);
            Assert.Equal(row1.TotalExento, 0);
            Assert.Equal(row1.TotalExonerado, 0);
            Assert.Equal(row1.TotalVenta, 3938.05);
            Assert.Equal(row1.TotalDescuentos, 0);
            Assert.Equal(row1.TotalVentaNeta, 3938.05);
            Assert.Equal(row1.TotalImpuesto, 511.9465);
            Assert.Equal(row1.TotalIVADevuelto, 0);
            Assert.Equal(row1.TotalOtrosCargos, 0);
            Assert.Equal(row1.TotalComprobante, 4449.9965);
        }
        #endregion
    }
}
