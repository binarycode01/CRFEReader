﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CR.XML.Reader.DA {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Query {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Query() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CR.XML.Reader.DA.Query", typeof(Query).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into
        ///	Factura  
        ///values 
        ///(
        ///	@Clave, 
        ///	@NumeroConsecutivo, 
        ///	@CodigoActividad, 
        ///	@FechaEmision, 
        ///	@EmisorNombre, 
        ///	@EmisorIdentificacionTipo, 
        ///	@EmisorIdentificacionNumero, 
        ///	@EmisorNombreComercial,
        ///	@EmisorUbicacionProvincia,
        ///    @EmisorUbicacionCanton, 
        ///	@EmisorUbicacionDistrito, 
        ///	@EmisorUbicacionBarrio,
        ///    @EmisorUbicacionOtrasSenas, 
        ///	@ReceptorNombre, 
        ///	@ReceptorIdentificacionTipo, 
        ///	@ReceptorIdentificacionNumero, 
        ///	@ReceptorIdentificacionExtranjero, 
        ///	@ReceptorNombreComercia [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InsertInvoice {
            get {
                return ResourceManager.GetString("InsertInvoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into FacturaDetalleCodigoComercial 
        ///Values
        ///(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@Tipo,
        ///	@Codigo
        ///).
        /// </summary>
        internal static string InsertInvoiceComercialCode {
            get {
                return ResourceManager.GetString("InsertInvoiceComercialCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert 	into 
        ///	FacturaDetalle 
        ///Values(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@Codigo,
        ///	@UnidadMedida,
        ///	@UnidadMedidaComercial,
        ///	@Detalle,
        ///	@PrecioUnitario,
        ///	@MontoTotal,
        ///	@SubTotal,
        ///	@BaseImponible,
        ///	@ImpuestoNeto,
        ///	@MontoTotalLinea
        ///).
        /// </summary>
        internal static string InsertInvoiceDetail {
            get {
                return ResourceManager.GetString("InsertInvoiceDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	FacturaDescuento
        ///Values 
        ///(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@MontoDescuento,
        ///	@NaturalezaDescuento
        ///).
        /// </summary>
        internal static string InsertInvoiceDiscount {
            get {
                return ResourceManager.GetString("InsertInvoiceDiscount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into FacturaOtrosCargos
        ///Values
        ///(
        ///	@Clave,
        ///	@TipoDocumento,
        ///	@NumeroIdentidadTercero,
        ///	@NombreTercero,
        ///	@Detalle,
        ///	@Porcentaje,
        ///	@MontoCargo
        ///).
        /// </summary>
        internal static string InsertInvoiceOtherCharges {
            get {
                return ResourceManager.GetString("InsertInvoiceOtherCharges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        ///	FacturaOtroContenido 
        ///Values 
        ///(
        ///	@Clave,
        ///	@Any,
        ///	@codigo
        ///).
        /// </summary>
        internal static string InsertInvoiceOtherContent {
            get {
                return ResourceManager.GetString("InsertInvoiceOtherContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        ///	FacturaOtrosTexto 
        ///Values
        ///(
        ///	@Clave,
        ///	@Codigo,
        ///	@Value
        ///).
        /// </summary>
        internal static string InsertInvoiceOtherText {
            get {
                return ResourceManager.GetString("InsertInvoiceOtherText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	FacturaMedioPago
        ///Values 
        ///	(@Clave, @MedioPago).
        /// </summary>
        internal static string InsertInvoicePaymentMethod {
            get {
                return ResourceManager.GetString("InsertInvoicePaymentMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	FacturaInformacionReferencia 
        ///Values
        ///(
        ///	@Clave,
        ///	@TipoDoc,
        ///	@Numero,
        ///	@FechaEmision,
        ///	@Codigo,
        ///	@Razon
        ///).
        /// </summary>
        internal static string InsertInvoiceReferences {
            get {
                return ResourceManager.GetString("InsertInvoiceReferences", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	FacturaImpuesto 
        ///
        ///Values 
        ///(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@Codigo,
        ///	@CodigoTarifa,
        ///	@Tarifa,
        ///	@FactorIVA,
        ///	@Monto,
        ///	@ExoneracionTipoDocumento,
        ///	@ExoneracionNumeroDocumento,
        ///	@ExoneracionNombreInstitucion,
        ///	@ExoneracionFechaEmision,
        ///	@ExoneracionPorcentaje,
        ///	@ExoneracionMonto
        ///).
        /// </summary>
        internal static string InsertInvoiceTaxDetail {
            get {
                return ResourceManager.GetString("InsertInvoiceTaxDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	FacturaResumen 
        ///Values 
        ///(
        ///	@Clave,
        ///	@CodigoTipoMoneda, @TipoCambio,
        ///	@TotalServGravados,
        ///	@TotalServExentos,
        ///	@TotalServExonerado,
        ///	@TotalMercanciasGravadas,
        ///	@TotalMercanciasExentas,
        ///	@TotalMercExonerada,
        ///	@TotalGravado,
        ///	@TotalExento,
        ///	@TotalExonerado,
        ///	@TotalVenta,
        ///	@TotalDescuentos,
        ///	@TotalVentaNeta,
        ///	@TotalImpuesto,
        ///	@TotalIVADevuelto,
        ///	@TotalOtrosCargos,
        ///	@TotalComprobante
        ///).
        /// </summary>
        internal static string InsertInvoiceTotals {
            get {
                return ResourceManager.GetString("InsertInvoiceTotals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into
        ///	Tiquete
        ///values 
        ///(
        ///	@Clave, 
        ///	@NumeroConsecutivo, 
        ///	@CodigoActividad, 
        ///	@FechaEmision, 
        ///	@EmisorNombre, 
        ///	@EmisorIdentificacionTipo, 
        ///	@EmisorIdentificacionNumero, 
        ///	@EmisorNombreComercial,
        ///	@EmisorUbicacionProvincia,
        ///    @EmisorUbicacionCanton, 
        ///	@EmisorUbicacionDistrito, 
        ///	@EmisorUbicacionBarrio,
        ///    @EmisorUbicacionOtrasSenas, 
        ///	@ReceptorNombre, 
        ///	@ReceptorIdentificacionTipo, 
        ///	@ReceptorIdentificacionNumero, 
        ///	@ReceptorIdentificacionExtranjero, 
        ///	@ReceptorNombreComercial, [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InsertTiquet {
            get {
                return ResourceManager.GetString("InsertTiquet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into TiqueteDetalleCodigoComercial 
        ///Values
        ///(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@Tipo,
        ///	@Codigo
        ///).
        /// </summary>
        internal static string InsertTiquetComercialCode {
            get {
                return ResourceManager.GetString("InsertTiquetComercialCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert 	into 
        ///	TiqueteDetalle 
        ///Values(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@Codigo,
        ///	@UnidadMedida,
        ///	@UnidadMedidaComercial,
        ///	@Detalle,
        ///	@PrecioUnitario,
        ///	@MontoTotal,
        ///	@SubTotal,
        ///	@BaseImponible,
        ///	@ImpuestoNeto,
        ///	@MontoTotalLinea
        ///).
        /// </summary>
        internal static string InsertTiquetDetail {
            get {
                return ResourceManager.GetString("InsertTiquetDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	TiqueteDescuento
        ///Values 
        ///(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@MontoDescuento,
        ///	@NaturalezaDescuento
        ///).
        /// </summary>
        internal static string InsertTiquetDiscount {
            get {
                return ResourceManager.GetString("InsertTiquetDiscount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into TiqueteOtrosCargos
        ///Values
        ///(
        ///	@Clave,
        ///	@TipoDocumento,
        ///	@NumeroIdentidadTercero,
        ///	@NombreTercero,
        ///	@Detalle,
        ///	@Porcentaje,
        ///	@MontoCargo
        ///).
        /// </summary>
        internal static string InsertTiquetOtherCharges {
            get {
                return ResourceManager.GetString("InsertTiquetOtherCharges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        ///	TiqueteOtroContenido 
        ///Values 
        ///(
        ///	@Clave,
        ///	@Any,
        ///	@codigo
        ///).
        /// </summary>
        internal static string InsertTiquetOtherContent {
            get {
                return ResourceManager.GetString("InsertTiquetOtherContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        ///	TiqueteOtrosTexto 
        ///Values
        ///(
        ///	@Clave,
        ///	@Codigo,
        ///	@Value
        ///).
        /// </summary>
        internal static string InsertTiquetOtherText {
            get {
                return ResourceManager.GetString("InsertTiquetOtherText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	TiqueteMedioPago
        ///Values 
        ///	(@Clave, @MedioPago).
        /// </summary>
        internal static string InsertTiquetPaymentMethod {
            get {
                return ResourceManager.GetString("InsertTiquetPaymentMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	TiqueteInformacionReferencia 
        ///Values
        ///(
        ///	@Clave,
        ///	@TipoDoc,
        ///	@Numero,
        ///	@FechaEmision,
        ///	@Codigo,
        ///	@Razon
        ///).
        /// </summary>
        internal static string InsertTiquetReferences {
            get {
                return ResourceManager.GetString("InsertTiquetReferences", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        ///	TiqueteImpuesto 
        ///
        ///Values 
        ///(
        ///	@Clave,
        ///	@NumeroLinea,
        ///	@Codigo,
        ///	@CodigoTarifa,
        ///	@Tarifa,
        ///	@FactorIVA,
        ///	@Monto,
        ///	@ExoneracionTipoDocumento,
        ///	@ExoneracionNumeroDocumento,
        ///	@ExoneracionNombreInstitucion,
        ///	@ExoneracionFechaEmision,
        ///	@ExoneracionPorcentaje,
        ///	@ExoneracionMonto
        ///).
        /// </summary>
        internal static string InsertTiquetTaxDetail {
            get {
                return ResourceManager.GetString("InsertTiquetTaxDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        ///	TiqueteResumen 
        ///Values 
        ///(
        ///	@Clave,
        ///	@CodigoTipoMoneda, @TipoCambio,
        ///	@TotalServGravados,
        ///	@TotalServExentos,
        ///	@TotalServExonerado,
        ///	@TotalMercanciasGravadas,
        ///	@TotalMercanciasExentas,
        ///	@TotalMercExonerada,
        ///	@TotalGravado,
        ///	@TotalExento,
        ///	@TotalExonerado,
        ///	@TotalVenta,
        ///	@TotalDescuentos,
        ///	@TotalVentaNeta,
        ///	@TotalImpuesto,
        ///	@TotalIVADevuelto,
        ///	@TotalOtrosCargos,
        ///	@TotalComprobante
        ///).
        /// </summary>
        internal static string InsertTiquetTotals {
            get {
                return ResourceManager.GetString("InsertTiquetTotals", resourceCulture);
            }
        }
    }
}
