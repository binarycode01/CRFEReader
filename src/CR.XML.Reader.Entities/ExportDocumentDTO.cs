namespace CR.XML.Reader.Entities
{
    public class ExportDocumentDTO
    {
        public string? Tipo { get; set; }

        public string? Clave { get; set; }

        public string? NumeroConsecutivo { get; set; }

        public string? CodigoActividad { get; set; }

        public DateTime FechaEmision { get; set; }

        public string? EmisorNombre { get; set; }

        public string? EmisorIdentificacionTipo { get; set; }

        public string? EmisorIdentificacionNumero { get; set; }

                
        public string? EmisorTelefonoNumTelefono { get; set; }

        public string? EmisorCorreoElectronico { get; set; }

        public string? ReceptorNombre { get; set; }

        public string? ReceptorIdentificacionTipo { get; set; }

        public string? ReceptorIdentificacionNumero { get; set; }

        public string? ReceptorIdentificacionExtranjero { get; set; }

        public string? ReceptorTelefonoCodigoPais { get; set; }

        public string? ReceptorTelefonoNumTelefono { get; set; }

        public string? PlazoCredito { get; set; }

        public string? CondicionVenta { get; set; }

        public string? CodigoTipoMoneda { get; set; }

        public double? TipoCambio { get; set; }

        public double TotalServExonerado { get; set; }

        public double TotalServExentos { get; set; }

        public double TotalMercanciasGravadas { get; set; }

        public double TotalMercanciasExentas { get; set; }

        public double TotalMercExonerada { get; set; }

        public double TotalGravado { get; set; }

        public double TotalExento { get; set; }

        public double TotalExonerado { get; set; }

        public double TotalVenta { get; set; }

        public double TotalImpuesto { get; set; }

        public double TotalIVADevuelto { get; set; }

        public double TotalOtrosCargos { get; set; }

        public double TotalComprobante { get; set; }
    }
}
