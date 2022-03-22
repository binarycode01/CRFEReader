﻿using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.Tiquete;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class TiquetRepository : GenericDocRepository<TiqueteElectronico>
    {
        #region Contructors
        public TiquetRepository (IDbConnection connection) : base (connection) { }
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
            this.Connection.Execute(Query.InsertTiquet, new
            {
                entity.Clave,
                entity.NumeroConsecutivo,
                entity.CodigoActividad,
                entity.FechaEmision,
                EmisorNombre = entity.Emisor.Nombre,
                EmisorIdentificacionTipo = EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Emisor.Identificacion.Tipo),
                EmisorIdentificacionNumero = entity.Emisor.Identificacion.Numero,
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
                CondicionVenta = entity.CodigoActividad,
                entity.PlazoCredito
            });
        }

        private void PaymentMethod(TiqueteElectronico entity)
        {
            foreach (var item in entity.MedioPago)
            {
                this.Connection.Execute(Query.InsertTiquetPaymentMethod, new
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
                this.Connection.Execute(Query.InsertTiquetDetail, new
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
                this.Connection.Execute(Query.InsertTiquetComercialCode, new
                {
                    Clave, 
                    NumeroLinea,
                    Tipo = item.Tipo,
                    Codigo = item.Codigo
                });
            }
        }

        private void TaxesDetail(string Clave, string Numerolinea, ImpuestoType[] taxes)
        {
            foreach (var item in taxes)
            {
                this.Connection.Execute(Query.InsertTiquetTaxDetail, new
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
                this.Connection.Execute(Query.InsertTiquetDiscount, new
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
                this.Connection.Execute(Query.InsertTiquetOtherCharges, new
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
            this.Connection.Execute(Query.InsertTiquetTotals, new
            {
                entity.Clave,
                CodigoTipoMoneda = entity.ResumenFactura.CodigoTipoMoneda.CodigoMoneda,
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
                this.Connection.Execute(Query.InsertTiquetReferences, new
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
                this.Connection.Execute(Query.InsertTiquetOtherText, new
                {
                    entity.Clave,
                    Codigo = item.codigo,
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
                this.Connection.Execute(Query.InsertTiquetOtherContent, new
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
