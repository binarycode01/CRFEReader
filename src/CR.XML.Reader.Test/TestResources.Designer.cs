﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CR.XML.Reader.Test {
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
    internal class TestResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CR.XML.Reader.Test.TestResources", typeof(TestResources).Assembly);
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
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;note&gt;
        ///  &lt;to&gt;Tove&lt;/to&gt;
        ///  &lt;from&gt;Jani&lt;/from&gt;
        ///  &lt;heading&gt;Reminder&lt;/heading&gt;
        ///  &lt;body&gt;Don&apos;t forget me this weekend!&lt;/body&gt;
        ///&lt;/note&gt;.
        /// </summary>
        internal static string InvalidXML {
            get {
                return ResourceManager.GetString("InvalidXML", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;FacturaElectronica xmlns=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica&quot; xsi:schemaLocation=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica https://www.hacienda.go.cr/ATV/ComprobanteElectronico/docs/esquemas/2016/v4.3/FacturaElectronica_V4.3.xsd&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:dsig=&quot;http://www.w3.org/2000/09/xmldsig#&quot;&gt;&lt;Clave&gt;50612032200310100718610400005010000020628188674153&lt;/ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RealFEText {
            get {
                return ResourceManager.GetString("RealFEText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;NotaCreditoElectronica xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/notaCreditoElectronica&quot;&gt;&lt;Clave&gt;50622022200011277076100100002030000000002100000007&lt;/Clave&gt;&lt;CodigoActividad&gt;722003&lt;/CodigoActividad&gt;&lt;NumeroConsecutivo&gt;00100002030000000002&lt;/NumeroConsecutivo&gt;&lt;FechaEmision&gt;2022-02-22T13:25:31Z&lt;/FechaEmision&gt;&lt;Emisor&gt;&lt;Nombre&gt;Diego Sánchez Salazar&lt;/Nombre&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RealNCText {
            get {
                return ResourceManager.GetString("RealNCText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;FacturaElectronicaCompra xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronicaCompra&quot;&gt;&lt;Clave&gt;50601102100310100000000100099080000000330100101620&lt;/Clave&gt;&lt;CodigoActividad&gt;960102&lt;/CodigoActividad&gt;&lt;NumeroConsecutivo&gt;00100099080000000330&lt;/NumeroConsecutivo&gt;&lt;FechaEmision&gt;2021-10-01T09:27:00&lt;/FechaEmision&gt;&lt;Emisor&gt;&lt;Nombre&gt;NOT VALID&lt;/Nombre&gt;&lt;Identifi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RealPurchaseText {
            get {
                return ResourceManager.GetString("RealPurchaseText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;TiqueteElectronico xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/tiqueteElectronico&quot;&gt;&lt;Clave&gt;50601112000310134740300100005040000105120300105120&lt;/Clave&gt;&lt;CodigoActividad&gt;523205&lt;/CodigoActividad&gt;&lt;NumeroConsecutivo&gt;00100005040000105120&lt;/NumeroConsecutivo&gt;&lt;FechaEmision&gt;2020-11-01T15:34:38&lt;/FechaEmision&gt;&lt;Emisor&gt;&lt;Nombre&gt;VENECORI, S.A.&lt;/Nombre&gt;&lt;Identificacion&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RealTiquetText {
            get {
                return ResourceManager.GetString("RealTiquetText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;&lt;TiqueteElectronico xmlns=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/tiqueteElectronico&quot; xsi:schemaLocation=&quot;https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/tiqueteElectronico https://www.hacienda.go.cr/ATV/ComprobanteElectronico/docs/esquemas/2016/v4.3/TiqueteElectronico_V4.3.xsd&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:dsig=&quot;http://www.w3.org/2000/09/xmldsig#&quot;&gt;&lt;Clave&gt;50630062400310123170700200099040000002216177046879&lt;/ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RealTiquetWithOtherXmls {
            get {
                return ResourceManager.GetString("RealTiquetWithOtherXmls", resourceCulture);
            }
        }
    }
}
