using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.FacturaExportacion;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class ExportInvoiceRepository : GenericDocRepository<FacturaElectronicaExportacion>
    {
        #region Contructors
        public ExportInvoiceRepository (IDbConnection connection, ILogger<CreditMemoRepository> logger) : base(connection, logger) { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "Exportacion"; } }

        public override void AddDocument(FacturaElectronicaExportacion entity)
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
        #endregion

        #region Private Methods
        private void Header(FacturaElectronicaExportacion entity)
        {
            this.Connection.Execute(string.Format(Query.InsertDocument, this.TableName), new
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
                EmisorTelefonoCodigoPais = entity.Emisor.Telefono != null ? entity.Emisor.Telefono.CodigoPais : null,
                EmisorTelefonoNumTelefono = entity.Emisor.Telefono != null ? entity.Emisor.Telefono.NumTelefono : null,
                EmisorCorreoElectronico = entity.Emisor.CorreoElectronico,
                ReceptorNombre = entity.Receptor != null ? entity.Receptor.Nombre : null,
                ReceptorIdentificacionTipo = entity.Receptor  != null && entity.Receptor.Identificacion != null ? EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Receptor.Identificacion.Tipo) : null,
                ReceptorIdentificacionNumero = entity.Receptor != null && entity.Receptor.Identificacion != null ? entity.Receptor.Identificacion.Numero : null,
                ReceptorIdentificacionExtranjero = entity.Receptor != null ? entity.Receptor.IdentificacionExtranjero : null,
                ReceptorNombreComercial = entity.Receptor != null ? entity.Receptor.NombreComercial : null,
                ReceptorUbicacionProvincia = string.Empty,
                ReceptorUbicacionCanton = string.Empty,
                ReceptorUbicacionDistrito = string.Empty,
                ReceptorUbicacionBarrio = string.Empty,
                ReceptorUbicacionOtrasSenas = string.Empty,
                ReceptorTelefonoCodigoPais = entity.Receptor != null && entity.Receptor.Telefono != null ? entity.Receptor.Telefono.CodigoPais : null,
                ReceptorTelefonoNumTelefono = entity.Receptor != null && entity.Receptor.Telefono != null ? entity.Receptor.Telefono.NumTelefono : null,
                ReceptorCorreoElectronico = entity.Receptor != null ? entity.Receptor.CorreoElectronico : null,
                CondicionVenta = EnumTools.GetXmlAttributeValue<FacturaElectronicaExportacionCondicionVenta>(entity.CondicionVenta),
                PlazoCredito = entity.PlazoCredito
            });
        }

        private void PaymentMethod(FacturaElectronicaExportacion entity)
        {
            HashSet<string> payMethod = new HashSet<string>();

            foreach (var item in entity.MedioPago)
            {
                if (payMethod.Contains(EnumTools.GetXmlAttributeValue<FacturaElectronicaExportacionMedioPago>(item)))
                    continue;

                payMethod.Add(EnumTools.GetXmlAttributeValue<FacturaElectronicaExportacionMedioPago>(item));

                this.Connection.Execute(string.Format(Query.InsertDocumentPaymentMethod, this.TableName), new
                {
                    Clave = entity.Clave,
                    MedioPago = EnumTools.GetXmlAttributeValue<FacturaElectronicaExportacionMedioPago>(item)
                });
            }
        }

        private void Detail(FacturaElectronicaExportacion entity)
        {
            if (entity.DetalleServicio is null)
                return;

            foreach (var item in entity.DetalleServicio)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentDetail, this.TableName), new
                {
                    entity.Clave,
                    item.NumeroLinea,
                    item.Codigo,
                    item.Cantidad,
                    UnidadMedida = item.UnidadMedida.ToString(),
                    item.UnidadMedidaComercial,
                    item.Detalle,
                    item.PrecioUnitario,
                    item.MontoTotal,
                    item.SubTotal,
                    BaseImponible = 0,
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
            if (comercialCodes is null)
                return;

            foreach (var item in comercialCodes)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentComercialCode, this.TableName), new
                {
                    Clave,
                    NumeroLinea,
                    Tipo = EnumTools.GetXmlAttributeValue<CodigoTypeTipo>(item.Tipo),
                    Codigo = item.Codigo
                });
            }
        }

        private void TaxesDetail(string Clave, string NumeroLinea, ImpuestoType[] taxes)
        {
            if (taxes is null)
                return;

            foreach (var item in taxes)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentTaxDetail, this.TableName), new
                {
                    Clave = Clave,
                    NumeroLinea = NumeroLinea,
                    Codigo = EnumTools.GetXmlAttributeValue<ImpuestoTypeCodigo>(item.Codigo),
                    CodigoTarifa = EnumTools.GetXmlAttributeValue<ImpuestoTypeCodigoTarifa>(item.CodigoTarifa),
                    Tarifa = item.Tarifa,
                    FactorIVA = item.FactorIVA,
                    Monto = item.Monto,
                    ExoneracionTipoDocumento = string.Empty,
                    ExoneracionNumeroDocumento = string.Empty,
                    ExoneracionNombreInstitucion = string.Empty,
                    ExoneracionFechaEmision = string.Empty,
                    ExoneracionPorcentaje = 0,
                    ExoneracionMonto = 0
                });
            }
        }

        private void DiscountsDetail(string Clave, string NumeroLinea, DescuentoType[] discounts)
        {
            if (discounts is null)
                return;

            foreach (var item in discounts)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentDiscount, TableName), new
                {
                    Clave,
                    NumeroLinea,
                    MontoDescuento = item.MontoDescuento,
                    NaturalezaDescuento = item.NaturalezaDescuento
                });
            }
        }

        private void OtherCharges(FacturaElectronicaExportacion entity)
        {
            if (entity.OtrosCargos is null)
                return;

            foreach (var item in entity.OtrosCargos)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherCharges, TableName), new
                {
                    entity.Clave,
                    TipoDocumento = EnumTools.GetXmlAttributeValue<OtrosCargosTypeTipoDocumento>(item.TipoDocumento),
                    NumeroIdentidadTercero = string.Empty,
                    NombreTercero = string.Empty,
                    item.Detalle,
                    item.Porcentaje,
                    item.MontoCargo
                });
            }
        }

        private void Totals(FacturaElectronicaExportacion entity)
        {
            this.Connection.Execute(string.Format(Query.InsertDocumentTotals, TableName), new
            {
                entity.Clave,
                CodigoTipoMoneda = entity.ResumenFactura.CodigoTipoMoneda != null ? EnumTools.GetXmlAttributeValue<CodigoMonedaTypeCodigoMoneda>(entity.ResumenFactura.CodigoTipoMoneda.CodigoMoneda) : null,
                TipoCambio = (Decimal?)(entity.ResumenFactura.CodigoTipoMoneda != null ? entity.ResumenFactura.CodigoTipoMoneda.TipoCambio : null),
                entity.ResumenFactura.TotalServGravados,
                entity.ResumenFactura.TotalServExentos,
                TotalServExonerado = 0,
                entity.ResumenFactura.TotalMercanciasGravadas,
                entity.ResumenFactura.TotalMercanciasExentas,
                TotalMercExonerada = 0,
                entity.ResumenFactura.TotalGravado,
                entity.ResumenFactura.TotalExento,
                TotalExonerado = 0,
                entity.ResumenFactura.TotalVenta,
                entity.ResumenFactura.TotalDescuentos,
                entity.ResumenFactura.TotalVentaNeta,
                entity.ResumenFactura.TotalImpuesto,
                TotalIVADevuelto = 0,
                entity.ResumenFactura.TotalOtrosCargos,
                entity.ResumenFactura.TotalComprobante
            });
        }

        private void References(FacturaElectronicaExportacion entity)
        {
            if (entity.InformacionReferencia == null)
                return;

            foreach (var item in entity.InformacionReferencia)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentReferences, TableName), new
                {
                    entity.Clave,
                    TipoDoc = EnumTools.GetXmlAttributeValue<FacturaElectronicaExportacionInformacionReferenciaTipoDoc>(item.TipoDoc),
                    item.Numero,
                    item.FechaEmision,
                    Codigo = EnumTools.GetXmlAttributeValue<FacturaElectronicaExportacionInformacionReferenciaCodigo>(item.Codigo),
                    item.Razon
                });
            }
        }

        private void OtherText(FacturaElectronicaExportacion entity)
        {
            if (entity.Otros is null || entity.Otros.OtroTexto is null)
                return;

            foreach (var item in entity.Otros.OtroTexto)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                    continue;

                this.Connection.Execute(string.Format(Query.InsertDocumentOtherText, TableName), new
                {
                    entity.Clave,
                    Codigo = item.codigo is null ? string.Empty : item.codigo,
                    item.Value
                });
            }
        }

        private void OtherContent(FacturaElectronicaExportacion entity)
        {
            if (entity.Otros is null || entity.Otros.OtroContenido is null)
                return;

            foreach (var item in entity.Otros.OtroContenido)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherContent, TableName), new
                {
                    entity.Clave,
                    Any = item.Any.InnerXml.ToString(),
                    codigo = item.codigo is null ? string.Empty : item.codigo
                });
            }
        }
        #endregion
    }
}
