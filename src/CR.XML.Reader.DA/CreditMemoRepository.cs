﻿using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.NotaCredito;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class CreditMemoRepository : GenericDocRepository<NotaCreditoElectronica> 
    {
        #region Constructors
        public CreditMemoRepository(IDbConnection connection) : base(connection)
        { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "NotaCredito"; } }

        public override void AddDocument(NotaCreditoElectronica entity)
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

        private void Header(NotaCreditoElectronica entity)
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
                ReceptorIdentificacionTipo = entity.Receptor != null ? EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Receptor.Identificacion.Tipo) : null,
                ReceptorIdentificacionNumero = entity.Receptor != null ? entity.Receptor.Identificacion.Numero : null,
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
                CondicionVenta = EnumTools.GetXmlAttributeValue<NotaCreditoElectronicaCondicionVenta>(entity.CondicionVenta),
                PlazoCredito = entity.PlazoCredito
            });
        }

        private void PaymentMethod(NotaCreditoElectronica entity)
        {
            foreach (var item in entity.MedioPago)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentPaymentMethod, this.TableName), new
                {
                    Clave = entity.Clave,
                    MedioPago = EnumTools.GetXmlAttributeValue<NotaCreditoElectronicaMedioPago>(item)
                });
            }
        }

        private void Detail(NotaCreditoElectronica entity)
        {
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
                this.Connection.Execute(string.Format(Query.InsertDocumentDiscount, TableName), new
                {
                    Clave,
                    NumeroLinea,
                    MontoDescuento = item.MontoDescuento,
                    NaturalezaDescuento = item.NaturalezaDescuento
                });
            }
        }

        private void OtherCharges(NotaCreditoElectronica entity)
        {
            if (entity.OtrosCargos is null)
                return;

            foreach (var item in entity.OtrosCargos)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherCharges, TableName), new
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

        private void Totals(NotaCreditoElectronica entity)
        {
            this.Connection.Execute(string.Format(Query.InsertDocumentTotals, TableName), new
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

        private void References(NotaCreditoElectronica entity)
        {
            if (entity.InformacionReferencia == null)
                return;

            foreach (var item in entity.InformacionReferencia)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentReferences, TableName), new
                {
                    entity.Clave,
                    TipoDoc = EnumTools.GetXmlAttributeValue<NotaCreditoElectronicaInformacionReferenciaTipoDoc>(item.TipoDoc),
                    item.Numero,
                    item.FechaEmision,
                    Codigo = EnumTools.GetXmlAttributeValue<NotaCreditoElectronicaInformacionReferenciaCodigo>(item.Codigo),
                    item.Razon
                });
            }
        }

        private void OtherText(NotaCreditoElectronica entity)
        {
            if (entity.Otros is null || entity.Otros.OtroTexto is null)
                return;

            foreach (var item in entity.Otros.OtroTexto)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherText, TableName), new
                {
                    entity.Clave,
                    Codigo = item.codigo,
                    item.Value
                });
            }
        }

        private void OtherContent(NotaCreditoElectronica entity)
        {
            if (entity.Otros is null || entity.Otros.OtroContenido is null)
                return;

            foreach (var item in entity.Otros.OtroContenido)
            {
                this.Connection.Execute(string.Format(Query.InsertDocumentOtherContent, TableName), new
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
