using FluentMigrator;

namespace CR.XML.Reader.DB
{
    [Migration(3, "Add the main tables for Credit Memo")]
    public class _0003_Add_CreditMemo_Tables : Migration
    {
        public override void Down()
        {
            Delete.Table("NotaCredito");
            Delete.Table("NotaCreditoMedioPago");
            Delete.Table("NotaCreditoDetalle");
            Delete.Table("NotaCreditoDetalleCodigoComercial");
            Delete.Table("NotaCreditoImpuesto");
            Delete.Table("NotaCreditoDescuento");
            Delete.Table("NotaCreditoOtrosCargos");
            Delete.Table("NotaCreditoResumen");
            Delete.Table("NotaCreditoInformacionReferencia");
            Delete.Table("NotaCreditoOtrosTexto");
            Delete.Table("NotaCreditoOtroContenido");
        }

        public override void Up()
        {
            // NotaCredito 
            Create.Table("NotaCredito")
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

            // NotaCreditoMedioPago
            Create.Table("NotaCreditoMedioPago")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave").PrimaryKey()
                .WithColumn("MedioPago").AsString().NotNullable().PrimaryKey();

            Create.Table("NotaCreditoDetalle")
              .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave").PrimaryKey()
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

            Create.Table("NotaCreditoDetalleCodigoComercial")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
                .WithColumn("NumeroLinea").AsString().NotNullable()
                .WithColumn("Tipo").AsString().Nullable()
                .WithColumn("Codigo").AsString().Nullable();

            // Impuestos tabla
            Create.Table("NotaCreditoImpuesto")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
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

            Create.Table("NotaCreditoDescuento")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
                .WithColumn("NumeroLinea").AsString().NotNullable()
                .WithColumn("MontoDescuento").AsDecimal().Nullable()
                .WithColumn("NaturalezaDescuento").AsDecimal().Nullable();

            Create.Table("NotaCreditoOtrosCargos")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
                .WithColumn("TipoDocumento").AsString()
                .WithColumn("NumeroIdentidadTercero").AsString().Nullable()
                .WithColumn("NombreTercero").AsString().Nullable()
                .WithColumn("Detalle").AsString().Nullable()
                .WithColumn("Porcentaje").AsDecimal().Nullable()
                .WithColumn("MontoCargo").AsDecimal().Nullable();

            Create.Table("NotaCreditoResumen")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave").PrimaryKey()
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

            Create.Table("NotaCreditoInformacionReferencia")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
                .WithColumn("TipoDoc").AsString().NotNullable()
                .WithColumn("Numero").AsString().Nullable()
                .WithColumn("FechaEmision").AsDateTime().Nullable()
                .WithColumn("Codigo").AsString().Nullable()
                .WithColumn("Razon").AsString().Nullable();

            Create.Table("NotaCreditoOtrosTexto")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
                .WithColumn("Codigo").AsString().NotNullable()
                .WithColumn("Value").AsString().NotNullable();

            Create.Table("NotaCreditoOtroContenido")
                .WithColumn("Clave").AsString().NotNullable().ForeignKey("NotaCredito", "Clave")
                .WithColumn("Any").AsString().NotNullable()
                .WithColumn("codigo").AsString().Nullable();
        }
    }
}
