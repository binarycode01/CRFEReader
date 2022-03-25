using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class InvoiceRepository : GenericDocRepository<FacturaElectronica>
    {
        #region Constructors
        public InvoiceRepository (IDbConnection connection) : base (connection) { }

        #endregion

        #region Overrides
        protected override string TableName { get { return "Factura"; } }

        public override void AddDocument(FacturaElectronica entity)
        {
            Header(entity);

            PaymentMethod(entity);

            Detail(entity);

            OtherCharges(entity);

            Totals(entity);

            References(entity);

            OtherText(entity);

            OtherContent(entity);

        }

        private void Header(FacturaElectronica entity)
        {
            this.Connection.Execute(Query.InsertInvoice, new
            {
                entity.Clave,
                entity.NumeroConsecutivo,
                entity.CodigoActividad,
                entity.FechaEmision,
                EmisorNombre = entity.Emisor.Nombre,
                EmisorIdentificacionTipo = EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Emisor.Identificacion.Tipo),
                EmisorIdentificacionNumero = entity.Emisor.Identificacion.Numero,
                EmisorNombreComercial = entity.Emisor.NombreComercial,
                EmisorUbicacionProvincia = entity.Emisor.Ubicacion != null ? entity.Emisor.Ubicacion.Provincia : null,
                EmisorUbicacionCanton = entity.Emisor.Ubicacion != null ? entity.Emisor.Ubicacion.Canton : null,
                EmisorUbicacionDistrito = entity.Emisor.Ubicacion != null ? entity.Emisor.Ubicacion.Distrito : null,
                EmisorUbicacionBarrio = entity.Emisor.Ubicacion != null ? entity.Emisor.Ubicacion.Barrio : null,
                EmisorUbicacionOtrasSenas = entity.Emisor.Ubicacion != null ? entity.Emisor.Ubicacion.OtrasSenas : null,
                ReceptorNombre = entity.Receptor != null ? entity.Receptor.Nombre : null,
                ReceptorIdentificacionTipo = entity.Receptor != null ? EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Receptor.Identificacion.Tipo) : null,
                ReceptorIdentificacionNumero = entity.Receptor != null ? entity.Receptor.Identificacion.Numero : null,
                ReceptorIdentificacionExtranjero = entity.Receptor != null ? entity.Receptor.IdentificacionExtranjero : null,
                ReceptorNombreComercial = entity.Receptor != null ? entity.Receptor.NombreComercial : null,
                ReceptorUbicacionProvincia = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Provincia : null,
                ReceptorUbicacionCanton = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Canton : null,
                ReceptorUbicacionDistrito = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Distrito : null,
                ReceptorUbicacionBarrio = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Barrio : null,
                ReceptorUbicacionOtrasSenas = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.OtrasSenas : null,
                CondicionVenta = EnumTools.GetXmlAttributeValue<FacturaElectronicaCondicionVenta>(entity.CondicionVenta),
                PlazoCredito = entity.PlazoCredito
            });
        }

        private void PaymentMethod(FacturaElectronica entity)
        {
            foreach (var item in entity.MedioPago)
            {
                this.Connection.Execute(Query.InsertInvoicePaymentMethod, new
                {
                    Clave = entity.Clave,
                    MedioPago = EnumTools.GetXmlAttributeValue<FacturaElectronicaMedioPago>(item)
                });
            }
        }

        private void Detail(FacturaElectronica entity)
        {
            foreach (var item in entity.DetalleServicio)
            {
                this.Connection.Execute(Query.InsertInvoiceDetail, new
                {
                    entity.Clave,
                    item.NumeroLinea,
                    item.Codigo,
                    UnidadMedida = item.UnidadMedida.ToString(),
                    item.UnidadMedidaComercial,
                    item.Detalle,
                    item.PrecioUnitario,
                    item.MontoTotal,
                    item.SubTotal,
                    item.BaseImponible,
                    item.ImpuestoNeto,
                    item.MontoTotalLinea
                });

                ComercialCodeDetail(entity.Clave, item.NumeroLinea, item.CodigoComercial);

                TaxesDetail(entity.Clave, item.NumeroLinea, item.Impuesto);

                DiscountsDetail(entity.Clave, item.NumeroLinea, item.Descuento);
            }
        }

        private void ComercialCodeDetail(string Clave, string NumeroLinea, CodigoType[] comercialCodes)
        {
            foreach (var item in comercialCodes)
            {
                this.Connection.Execute(Query.InsertInvoiceComercialCode, new
                {
                    Clave,
                    NumeroLinea,
                    Tipo = EnumTools.GetXmlAttributeValue<CodigoTypeTipo>(item.Tipo),
                    Codigo = item.Codigo
                });
            }
        }

        private void TaxesDetail(string clave, string numeroLinea, ImpuestoType[] taxes)
        {
            if (taxes is null)
                return;

            foreach (var item in taxes)
            {
                this.Connection.Execute(Query.InsertInvoiceTaxDetail, new
                {
                    Clave = clave,
                    NumeroLinea = numeroLinea,
                    Codigo = EnumTools.GetXmlAttributeValue<ImpuestoTypeCodigo>(item.Codigo),
                    CodigoTarifa = EnumTools.GetXmlAttributeValue<ImpuestoTypeCodigoTarifa>(item.CodigoTarifa),
                    Tarifa = item.Tarifa,
                    FactorIVA = item.FactorIVA,
                    Monto = item.Monto,
                    ExoneracionTipoDocumento = item.Exoneracion != null ? EnumTools.GetXmlAttributeValue<ExoneracionTypeTipoDocumento>(item.Exoneracion.TipoDocumento) : null,
                    ExoneracionNumeroDocumento = item.Exoneracion != null ? item.Exoneracion.NumeroDocumento : null,
                    ExoneracionNombreInstitucion = item.Exoneracion != null ? item.Exoneracion.NombreInstitucion : null,
                    ExoneracionFechaEmision = (DateTime?)(item.Exoneracion != null ? item.Exoneracion.FechaEmision : null),
                    ExoneracionPorcentaje = item.Exoneracion != null ? item.Exoneracion.PorcentajeExoneracion : null,
                    ExoneracionMonto = (Decimal?)(item.Exoneracion != null ? item.Exoneracion.MontoExoneracion : null)
                });
            }
        }

        private void DiscountsDetail(string Clave, string NumeroLinea, DescuentoType[] discounts)
        {
            if (discounts is null)
                return;

            foreach (var item in discounts)
            {
                this.Connection.Execute(Query.InsertTiquetDiscount, new
                {
                    Clave,
                    NumeroLinea,
                    MontoDescuento = item.MontoDescuento,
                    NaturalezaDescuento = item.NaturalezaDescuento
                });
            }
        }

        private void OtherCharges(FacturaElectronica entity)
        {
            if (entity.OtrosCargos is null)
                return;

            foreach (var item in entity.OtrosCargos)
            {
                this.Connection.Execute(Query.InsertInvoiceOtherCharges, new
                {
                    entity.Clave,
                    TipoDocumento = EnumTools.GetXmlAttributeValue<OtrosCargosTypeTipoDocumento>(item.TipoDocumento),
                    item.NumeroIdentidadTercero,
                    item.NombreTercero,
                    item.Detalle,
                    item.Porcentaje,
                    item.MontoCargo
                });
            }
        }

        private void Totals(FacturaElectronica entity)
        {
            this.Connection.Execute(Query.InsertInvoiceTotals, new
            {
                entity.Clave,
                CodigoTipoMoneda = entity.ResumenFactura.CodigoTipoMoneda != null ? EnumTools.GetXmlAttributeValue<CodigoMonedaTypeCodigoMoneda>(entity.ResumenFactura.CodigoTipoMoneda.CodigoMoneda) : null,
                TipoCambio = (Decimal?)(entity.ResumenFactura.CodigoTipoMoneda != null ? entity.ResumenFactura.CodigoTipoMoneda.TipoCambio : null),
                entity.ResumenFactura.TotalServGravados,
                entity.ResumenFactura.TotalServExentos,
                entity.ResumenFactura.TotalServExonerado,
                entity.ResumenFactura.TotalMercanciasGravadas,
                entity.ResumenFactura.TotalMercanciasExentas,
                entity.ResumenFactura.TotalMercExonerada,
                entity.ResumenFactura.TotalGravado,
                entity.ResumenFactura.TotalExento,
                entity.ResumenFactura.TotalExonerado,
                entity.ResumenFactura.TotalVenta,
                entity.ResumenFactura.TotalDescuentos,
                entity.ResumenFactura.TotalVentaNeta,
                entity.ResumenFactura.TotalImpuesto,
                entity.ResumenFactura.TotalIVADevuelto,
                entity.ResumenFactura.TotalOtrosCargos,
                entity.ResumenFactura.TotalComprobante
            });
        }

        private void References(FacturaElectronica entity)
        {
            if (entity.InformacionReferencia == null)
                return;

            foreach (var item in entity.InformacionReferencia)
            {
                this.Connection.Execute(Query.InsertInvoiceReferences, new
                {
                    entity.Clave,
                    TipoDoc = EnumTools.GetXmlAttributeValue<FacturaElectronicaInformacionReferenciaTipoDoc>(item.TipoDoc),
                    item.Numero,
                    item.FechaEmision,
                    Codigo = EnumTools.GetXmlAttributeValue<FacturaElectronicaInformacionReferenciaCodigo>(item.Codigo),
                    item.Razon
                });
            }
        }

        private void OtherText(FacturaElectronica entity)
        {
            if (entity.Otros is null || entity.Otros.OtroTexto is null)
                return;

            foreach (var item in entity.Otros.OtroTexto)
            {
                this.Connection.Execute(Query.InsertInvoiceOtherText, new
                {
                    entity.Clave,
                    Codigo = item.codigo,
                    item.Value
                });
            }
        }

        private void OtherContent(FacturaElectronica entity)
        {
            if (entity.Otros is null || entity.Otros.OtroContenido is null)
                return;

            foreach (var item in entity.Otros.OtroContenido)
            {
                this.Connection.Execute(Query.InsertInvoiceOtherContent, new
                {
                    entity.Clave,
                    Any = item.Any.ToString(),
                    codigo = item.codigo
                });
            }
        }
        #endregion
    }
}