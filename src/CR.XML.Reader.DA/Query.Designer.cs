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
        ///   Looks up a localized string similar to select min(FechaEmision) as FechaMinima,  max(FechaEmision) as FechaMaxima from Cabecera.
        /// </summary>
        internal static string BetweenDates {
            get {
                return ResourceManager.GetString("BetweenDates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into
        /// {0}  
        ///values 
        ///(
        /// @Clave, 
        /// @NumeroConsecutivo, 
        /// @CodigoActividad, 
        /// @FechaEmision, 
        /// @EmisorNombre, 
        /// @EmisorIdentificacionTipo, 
        /// @EmisorIdentificacionNumero, 
        /// @EmisorNombreComercial,
        /// @EmisorUbicacionProvincia,
        ///    @EmisorUbicacionCanton, 
        /// @EmisorUbicacionDistrito, 
        /// @EmisorUbicacionBarrio,
        ///    @EmisorUbicacionOtrasSenas, @EmisorTelefonoCodigoPais, @EmisorTelefonoNumTelefono, @EmisorCorreoElectronico,
        /// @ReceptorNombre, 
        /// @ReceptorIdentificacionTipo, 
        /// @ReceptorIdentifica [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InsertDocument {
            get {
                return ResourceManager.GetString("InsertDocument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into {0}DetalleCodigoComercial 
        ///Values
        ///(
        /// @Clave,
        /// @NumeroLinea,
        /// @Tipo,
        /// @Codigo
        ///)
        ///.
        /// </summary>
        internal static string InsertDocumentComercialCode {
            get {
                return ResourceManager.GetString("InsertDocumentComercialCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert  into 
        /// {0}Detalle 
        ///Values(
        /// @Clave,
        /// @NumeroLinea,
        /// @Codigo, @Cantidad,
        /// @UnidadMedida,
        /// @UnidadMedidaComercial,
        /// @Detalle,
        /// @PrecioUnitario,
        /// @MontoTotal,
        /// @SubTotal,
        /// @BaseImponible,
        /// @ImpuestoNeto,
        /// @MontoTotalLinea
        ///).
        /// </summary>
        internal static string InsertDocumentDetail {
            get {
                return ResourceManager.GetString("InsertDocumentDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        /// {0}Descuento
        ///Values 
        ///(
        /// @Clave,
        /// @NumeroLinea,
        /// @MontoDescuento,
        /// @NaturalezaDescuento
        ///).
        /// </summary>
        internal static string InsertDocumentDiscount {
            get {
                return ResourceManager.GetString("InsertDocumentDiscount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into {0}OtrosCargos
        ///Values
        ///(
        /// @Clave,
        /// @TipoDocumento,
        /// @NumeroIdentidadTercero,
        /// @NombreTercero,
        /// @Detalle,
        /// @Porcentaje,
        /// @MontoCargo
        ///).
        /// </summary>
        internal static string InsertDocumentOtherCharges {
            get {
                return ResourceManager.GetString("InsertDocumentOtherCharges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        /// {0}OtroContenido 
        ///Values 
        ///(
        /// @Clave,
        /// @Any,
        /// @codigo
        ///).
        /// </summary>
        internal static string InsertDocumentOtherContent {
            get {
                return ResourceManager.GetString("InsertDocumentOtherContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into 
        /// {0}OtrosTexto 
        ///Values
        ///(
        /// @Clave,
        /// @Codigo,
        /// @Value
        ///).
        /// </summary>
        internal static string InsertDocumentOtherText {
            get {
                return ResourceManager.GetString("InsertDocumentOtherText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        /// {0}MedioPago
        ///Values 
        /// (@Clave, @MedioPago).
        /// </summary>
        internal static string InsertDocumentPaymentMethod {
            get {
                return ResourceManager.GetString("InsertDocumentPaymentMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        /// {0}InformacionReferencia 
        ///Values
        ///(
        /// @Clave,
        /// @TipoDoc,
        /// @Numero,
        /// @FechaEmision,
        /// @Codigo,
        /// @Razon
        ///).
        /// </summary>
        internal static string InsertDocumentReferences {
            get {
                return ResourceManager.GetString("InsertDocumentReferences", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        /// {0}Impuesto 
        ///
        ///Values 
        ///(
        /// @Clave,
        /// @NumeroLinea,
        /// @Codigo,
        /// @CodigoTarifa,
        /// @Tarifa,
        /// @FactorIVA,
        /// @Monto,
        /// @ExoneracionTipoDocumento,
        /// @ExoneracionNumeroDocumento,
        /// @ExoneracionNombreInstitucion,
        /// @ExoneracionFechaEmision,
        /// @ExoneracionPorcentaje,
        /// @ExoneracionMonto
        ///).
        /// </summary>
        internal static string InsertDocumentTaxDetail {
            get {
                return ResourceManager.GetString("InsertDocumentTaxDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert into 
        /// {0}Resumen 
        ///Values 
        ///(
        /// @Clave,
        /// @CodigoTipoMoneda, @TipoCambio,
        /// @TotalServGravados,
        /// @TotalServExentos,
        /// @TotalServExonerado,
        /// @TotalMercanciasGravadas,
        /// @TotalMercanciasExentas,
        /// @TotalMercExonerada,
        /// @TotalGravado,
        /// @TotalExento,
        /// @TotalExonerado,
        /// @TotalVenta,
        /// @TotalDescuentos,
        /// @TotalVentaNeta,
        /// @TotalImpuesto,
        /// @TotalIVADevuelto,
        /// @TotalOtrosCargos,
        /// @TotalComprobante
        ///).
        /// </summary>
        internal static string InsertDocumentTotals {
            get {
                return ResourceManager.GetString("InsertDocumentTotals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count( Distinct EmisorIdentificacionNumero) as Cantidad from Cabecera.
        /// </summary>
        internal static string TotalCompanies {
            get {
                return ResourceManager.GetString("TotalCompanies", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select count(1) as Cantidad from Cabecera.
        /// </summary>
        internal static string TotalDocuments {
            get {
                return ResourceManager.GetString("TotalDocuments", resourceCulture);
            }
        }
    }
}
