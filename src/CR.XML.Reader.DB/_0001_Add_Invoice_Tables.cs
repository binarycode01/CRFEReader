using FluentMigrator;

namespace CR.XML.Reader.DB
{
    [Migration(1, "Add the main tables")]
    public class _0001_Add_Invoice_Tables : Migration
    {
        private static readonly string[] MainTables = new string[] { "Factura", "Tiquete", "NotaCredito", "NotaDebito", "Exportacion", "FacturaCompra" };

        public override void Down()
        {
            foreach (var table in MainTables)
            {
                Delete.Table($"{table}");
                Delete.Table($"{table}MedioPago");
                Delete.Table($"{table}Detalle");
                Delete.Table($"{table}DetalleCodigoComercial");
                Delete.Table($"{table}Impuesto");
                Delete.Table($"{table}Descuento");
                Delete.Table($"{table}OtrosCargos");
                Delete.Table($"{table}Resumen");
                Delete.Table($"{table}InformacionReferencia");
                Delete.Table($"{table}OtrosTexto");
                Delete.Table($"{table}OtroContenido");
            }
        }

        public override void Up()
        {
            foreach (var table in MainTables)
            {
                // TODO: Telefono, Correo.
                Create.Table($"{table}")
                    .WithColumn("Clave").AsString().PrimaryKey().NotNullable()
                    .WithColumn("NumeroConsecutivo").AsString().NotNullable()
                    .WithColumn("CodigoActividad").AsString().Nullable()
                    .WithColumn("FechaEmision").AsDateTime().Nullable()
                    .WithColumn("EmisorNombre").AsString().Nullable()
                    .WithColumn("EmisorIdentificacionTipo").AsString().Nullable()
                    .WithColumn("EmisorIdentificacionNumero").AsString().Nullable()
                    .WithColumn("EmisorNombreComercial").AsString().Nullable()
                    .WithColumn("EmisorUbicacionProvincia").AsString().Nullable()
                    .WithColumn("EmisorUbicacionCanton").AsString().Nullable()
                    .WithColumn("EmisorUbicacionDistrito").AsString().Nullable()
                    .WithColumn("EmisorUbicacionBarrio").AsString().Nullable()
                    .WithColumn("EmisorUbicacionOtrasSenas").AsString().Nullable()
                    .WithColumn("ReceptorNombre").AsString().Nullable()
                    .WithColumn("ReceptorIdentificacionTipo").AsString().Nullable()
                    .WithColumn("ReceptorIdentificacionNumero").AsString().Nullable()
                    .WithColumn("ReceptorIdentificacionExtranjero").AsString().Nullable()
                    .WithColumn("ReceptorNombreComercial").AsString().Nullable()
                    .WithColumn("ReceptorUbicacionProvincia").AsString().Nullable()
                    .WithColumn("ReceptorUbicacionCanton").AsString().Nullable()
                    .WithColumn("ReceptorUbicacionDistrito").AsString().Nullable()
                    .WithColumn("ReceptorUbicacionBarrio").AsString().Nullable()
                    .WithColumn("ReceptorUbicacionOtrasSenas").AsString().Nullable()
                    .WithColumn("CondicionVenta").AsString().Nullable()
                    .WithColumn("PlazoCredito").AsString().Nullable();

                Create.Table($"{table}MedioPago")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave").PrimaryKey()
                    .WithColumn("MedioPago").AsString().NotNullable().PrimaryKey();

                Create.Table($"{table}Detalle")
                  .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave").PrimaryKey()
                  .WithColumn("NumeroLinea").AsString().NotNullable().PrimaryKey()
                  .WithColumn("Codigo").AsString().Nullable()
                  .WithColumn("UnidadMedida").AsString().Nullable()
                  .WithColumn("UnidadMedidaComercial").AsString().Nullable()
                  .WithColumn("Detalle").AsString().Nullable()
                  .WithColumn("PrecioUnitario").AsDecimal().Nullable()
                  .WithColumn("MontoTotal").AsDecimal().Nullable()
                  .WithColumn("SubTotal").AsDecimal()
                  .WithColumn("BaseImponible").AsDecimal()
                  .WithColumn("ImpuestoNeto").AsDecimal()
                  .WithColumn("MontoTotalLinea").AsDecimal();

                Create.Table($"{table}DetalleCodigoComercial")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("NumeroLinea").AsString().NotNullable()
                    .WithColumn("Tipo").AsString().Nullable()
                    .WithColumn("Codigo").AsString().Nullable();

                // Impuestos tabla
                Create.Table($"{table}Impuesto")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("NumeroLinea").AsString().NotNullable()
                    .WithColumn("Codigo").AsString().NotNullable()
                    .WithColumn("CodigoTarifa").AsString().NotNullable()
                    .WithColumn("Tarifa").AsDecimal().Nullable()
                    .WithColumn("FactorIVA").AsDecimal().Nullable()
                    .WithColumn("Monto").AsDecimal().Nullable()
                    .WithColumn("ExoneracionTipoDocumento").AsDecimal().Nullable()
                    .WithColumn("ExoneracionNumeroDocumento").AsDecimal().Nullable()
                    .WithColumn("ExoneracionNombreInstitucion").AsDecimal().Nullable()
                    .WithColumn("ExoneracionFechaEmision").AsDecimal().Nullable()
                    .WithColumn("ExoneracionPorcentaje").AsString().Nullable()
                    .WithColumn("ExoneracionMonto").AsDecimal().Nullable();

                Create.Table($"{table}Descuento")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("NumeroLinea").AsString().NotNullable()
                    .WithColumn("MontoDescuento").AsDecimal().Nullable()
                    .WithColumn("NaturalezaDescuento").AsDecimal().Nullable();

                Create.Table($"{table}OtrosCargos")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("TipoDocumento").AsString()
                    .WithColumn("NumeroIdentidadTercero").AsString().Nullable()
                    .WithColumn("NombreTercero").AsString().Nullable()
                    .WithColumn("Detalle").AsString().Nullable()
                    .WithColumn("Porcentaje").AsDecimal().Nullable()
                    .WithColumn("MontoCargo").AsDecimal().Nullable();

                Create.Table($"{table}Resumen")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave").PrimaryKey()
                    .WithColumn("CodigoTipoMoneda").AsString().Nullable()
                    .WithColumn("TipoCambio").AsDecimal().Nullable()
                    .WithColumn("TotalServGravados").AsDecimal().Nullable()
                    .WithColumn("TotalServExentos").AsDecimal().Nullable()
                    .WithColumn("TotalServExonerado").AsDecimal().Nullable()
                    .WithColumn("TotalMercanciasGravadas").AsDecimal().Nullable()
                    .WithColumn("TotalMercanciasExentas").AsDecimal().Nullable()
                    .WithColumn("TotalMercExonerada").AsDecimal().Nullable()
                    .WithColumn("TotalGravado").AsDecimal().Nullable()
                    .WithColumn("TotalExento").AsDecimal().Nullable()
                    .WithColumn("TotalExonerado").AsDecimal().Nullable()
                    .WithColumn("TotalVenta").AsDecimal().Nullable()
                    .WithColumn("TotalDescuentos").AsDecimal().Nullable()
                    .WithColumn("TotalVentaNeta").AsDecimal().Nullable()
                    .WithColumn("TotalImpuesto").AsDecimal().Nullable()
                    .WithColumn("TotalIVADevuelto").AsDecimal().Nullable()
                    .WithColumn("TotalOtrosCargos").AsDecimal().Nullable()
                    .WithColumn("TotalComprobante").AsDecimal().Nullable();

                Create.Table($"{table}InformacionReferencia")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("TipoDoc").AsString().NotNullable()
                    .WithColumn("Numero").AsString().Nullable()
                    .WithColumn("FechaEmision").AsDateTime().Nullable()
                    .WithColumn("Codigo").AsString().Nullable()
                    .WithColumn("Razon").AsString().Nullable();

                Create.Table($"{table}OtrosTexto")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("Codigo").AsString().NotNullable()
                    .WithColumn("Value").AsString().NotNullable();

                Create.Table($"{table}OtroContenido")
                    .WithColumn("Clave").AsString().NotNullable().ForeignKey($"{table}", "Clave")
                    .WithColumn("Any").AsString().NotNullable()
                    .WithColumn("codigo").AsString().Nullable();
            }
        }
    }
}