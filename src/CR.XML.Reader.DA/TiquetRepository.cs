using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.Tiquete;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class TiquetRepository : GenericDocRepository<TiqueteElectronico>
    {
        #region Contructors
        public TiquetRepository(IDbConnection connection, ILogger<TiquetRepository> logger) : base (connection, logger) { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "Tiquete"; } }

        public override void AddDocument(TiqueteElectronico entity)
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
        private void Header(TiqueteElectronico entity)
        {
            this.Connection.Execute(string.Format(Query.InsertDocument, TableName), new
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
                ReceptorIdentificacionTipo = entity.Receptor != null && entity.Receptor.Identificacion != null ? EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Receptor.Identificacion.Tipo) : null,
                ReceptorIdentificacionNumero = entity.Receptor != null && entity.Receptor.Identificacion != null ? entity.Receptor.Identificacion.Numero : null,
                ReceptorIdentificacionExtranjero = entity.Receptor != null ? entity.Receptor.IdentificacionExtranjero : null,
                ReceptorNombreComercial = entity.Receptor != null ? entity.Receptor.NombreComercial : null,
                ReceptorUbicacionProvincia = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Provincia : null,
                ReceptorUbicacionCanton = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Canton : null,
                ReceptorUbicacionDistrito = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Distrito : null,
                ReceptorUbicacionBarrio = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Barrio : null,
                ReceptorUbicacionOtrasSenas = entity.Receptor != null && entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.OtrasSenas : null,
                ReceptorTelefonoCodigoPais = entity.Receptor != null && entity.Receptor.Telefono != null ? entity.Receptor.Telefono.CodigoPais : null,
                ReceptorTelefonoNumTelefono = entity.Receptor != null && entity.Receptor.Telefono != null ? entity.Receptor.Telefono.NumTelefono : null,
                ReceptorCorreoElectronico = entity.Receptor != null ? entity.Receptor.CorreoElectronico : null,
                CondicionVenta = EnumTools.GetXmlAttributeValue<TiqueteElectronicoCondicionVenta> (entity.CondicionVenta),
                PlazoCredito = entity.PlazoCredito
            });
        }

        private void PaymentMethod(TiqueteElectronico entity)
        {
            HashSet<string> payMethod = new HashSet<string>();

            foreach (var item in entity.MedioPago)
            {
                if (payMethod.Contains(EnumTools.GetXmlAttributeValue<TiqueteElectronicoMedioPago>(item)))
                    continue;

                payMethod.Add(EnumTools.GetXmlAttributeValue<TiqueteElectronicoMedioPago>(item));

                this.Connection.Execute( string.Format(Query.InsertDocumentPaymentMethod, TableName), new
                {
                    Clave = entity.Clave,
                    MedioPago = EnumTools.GetXmlAttributeValue<TiqueteElectronicoMedioPago>(item)
                });
            }
        }

        private void Detail(TiqueteElectronico entity)
        {
            foreach (var item in entity.DetalleServicio)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentDetail, TableName), new
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
            if (comercialCodes is null)
                return;

            foreach (var item in comercialCodes)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentComercialCode, TableName), new
                {
                    Clave, 
                    NumeroLinea,
                    Tipo = EnumTools.GetXmlAttributeValue<CodigoTypeTipo>(item.Tipo),
                    Codigo = item.Codigo
                });
            }
        }

        private void TaxesDetail(string Clave, string Numerolinea, ImpuestoType[] taxes)
        {
            if (taxes is null)
                return;

            foreach (var item in taxes)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentTaxDetail, TableName), new
                {
                    Clave = Clave,
                    NumeroLinea = Numerolinea,
                    Codigo = EnumTools.GetXmlAttributeValue<ImpuestoTypeCodigo>(item.Codigo),
                    CodigoTarifa = EnumTools.GetXmlAttributeValue<ImpuestoTypeCodigoTarifa>(item.CodigoTarifa),
                    Tarifa= item.Tarifa,
                    FactorIVA = item.FactorIVA,
                    Monto = item.Monto,
                    ExoneracionTipoDocumento = item.Exoneracion != null ? EnumTools.GetXmlAttributeValue<ExoneracionTypeTipoDocumento>(item.Exoneracion.TipoDocumento) : null,
                    ExoneracionNumeroDocumento = item.Exoneracion != null ? item.Exoneracion.NumeroDocumento : null,
                    ExoneracionNombreInstitucion = item.Exoneracion != null ? item.Exoneracion.NombreInstitucion : null,
                    ExoneracionFechaEmision = (DateTime?)(item.Exoneracion != null ? item.Exoneracion.FechaEmision : null),
                    ExoneracionPorcentaje = item.Exoneracion != null ? item.Exoneracion.PorcentajeExoneracion : null,
                    ExoneracionMonto = (Decimal?)(item.Exoneracion != null ? item.Exoneracion.MontoExoneracion: null)
                }) ;
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

        private void OtherCharges(TiqueteElectronico entity)
        {
            if (entity.OtrosCargos is null)
                return;
            
            foreach (var item in entity.OtrosCargos)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherCharges, TableName), new
                {
                    entity.Clave,
                    TipoDocumento =  EnumTools.GetXmlAttributeValue <OtrosCargosTypeTipoDocumento>(item.TipoDocumento),
                    item.NumeroIdentidadTercero,
                    item.NombreTercero,
                    item.Detalle,
                    item.Porcentaje,
                    item.MontoCargo
                });
            }
        }

        private void Totals(TiqueteElectronico entity)
        {
            this.Connection.Execute(string.Format(Query.InsertDocumentTotals, TableName), new
            {
                entity.Clave,
                CodigoTipoMoneda = entity.ResumenFactura.CodigoTipoMoneda != null ? EnumTools.GetXmlAttributeValue <CodigoMonedaTypeCodigoMoneda>(entity.ResumenFactura.CodigoTipoMoneda.CodigoMoneda) : null,
                TipoCambio = (Decimal?) (entity.ResumenFactura.CodigoTipoMoneda != null ? entity.ResumenFactura.CodigoTipoMoneda.TipoCambio : null),
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

        private void References(TiqueteElectronico entity)
        {
            if (entity.InformacionReferencia == null)
                return;

            foreach (var item in entity.InformacionReferencia)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentReferences, TableName), new
                {
                    entity.Clave,
                    TipoDoc = EnumTools.GetXmlAttributeValue<TiqueteElectronicoInformacionReferenciaTipoDoc>(item.TipoDoc),
                    item.Numero,
                    item.FechaEmision,
                    Codigo = EnumTools.GetXmlAttributeValue<TiqueteElectronicoInformacionReferenciaCodigo>(item.Codigo),
                    item.Razon
                });
            }
        }

        private void OtherText(TiqueteElectronico entity)
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

        private void OtherContent(TiqueteElectronico entity)
        {
            if (entity.Otros is null || entity.Otros.OtroContenido is null)
                return;

            foreach (var item in entity.Otros.OtroContenido)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherContent), new
                {
                    entity.Clave,
                    Any = item.Any.ToString(),
                    item.codigo
                });
            }
        }
        #endregion
    }
}
