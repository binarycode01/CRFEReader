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
            this.Connection.Execute(Query.InsertInvoice, new
            {
                Clave = entity.Clave,
                NumeroConsecutivo = entity.NumeroConsecutivo,
                CodigoActividad = entity.CodigoActividad,
                FechaEmision = entity.FechaEmision,
                EmisorNombre = entity.Emisor.Nombre,
                EmisorIdentificacionTipo = EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Emisor.Identificacion.Tipo),
                EmisorIdentificacionNumero = entity.Emisor.Identificacion.Numero,
                ReceptorNombre = entity.Receptor.Nombre,
                ReceptorIdentificacionTipo = EnumTools.GetXmlAttributeValue<IdentificacionTypeTipo>(entity.Receptor.Identificacion.Tipo),
                ReceptorIdentificacionNumero = entity.Receptor.Identificacion.Numero,
                ReceptorIdentificacionExtranjero = entity.Receptor.IdentificacionExtranjero,
                ReceptorNombreComercial = entity.Receptor.NombreComercial,
                ReceptorUbicacionProvincia = entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Provincia : null,
                ReceptorUbicacionCanton = entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Canton : null,
                ReceptorUbicacionDistrito = entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Distrito : null,
                ReceptorUbicacionBarrio = entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.Barrio : null,
                ReceptorUbicacionOtrasSenas = entity.Receptor.Ubicacion != null ? entity.Receptor.Ubicacion.OtrasSenas : null,
                CondicionVenta = entity.CodigoActividad.ToString(),
                PlazoCredito = entity.PlazoCredito
            });

            foreach (var item in entity.MedioPago)
            {
                this.Connection.Execute(Query.InsertInvoicePaymentMethod, new
                {
                    Clave = entity.Clave, 
                    MedioPago = EnumTools.GetXmlAttributeValue <FacturaElectronicaMedioPago> (item)
                });
            }

        }
        #endregion 
    }
}