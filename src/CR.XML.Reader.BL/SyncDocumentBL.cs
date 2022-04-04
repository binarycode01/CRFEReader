using CR.XML.Reader.DA;
using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using CR.XML.Reader.Entities.XSD.v43.FacturaCompra;
using CR.XML.Reader.Entities.XSD.v43.FacturaExportacion;
using CR.XML.Reader.Entities.XSD.v43.NotaCredito;
using CR.XML.Reader.Entities.XSD.v43.NotaDebito;
using CR.XML.Reader.Entities.XSD.v43.Tiquete;

namespace CR.XML.Reader.BL
{
    public class SyncDocumentBL : ISyncDocumentBL
    {
        #region Atributes
        private readonly IRepository<FacturaElectronica> InvoiceRepository;
        private readonly IRepository<TiqueteElectronico> TiquetRepository;
        private readonly IRepository<NotaCreditoElectronica> CreditMemoRepository;
        private readonly IRepository<NotaDebitoElectronica> DebitMemoRepository;
        private readonly IRepository<FacturaElectronicaExportacion> ExportInvoiceRepository;
        private readonly IRepository<FacturaElectronicaCompra> PurchaseInvoiceRepository;
        #endregion 

        #region Constructors
        public SyncDocumentBL(IRepository<FacturaElectronica> InvoiceRepo, 
                              IRepository<TiqueteElectronico> TiqueteRepo,
                              IRepository<NotaCreditoElectronica> CreditRepo, 
                              IRepository<NotaDebitoElectronica> DebitRepo,
                              IRepository<FacturaElectronicaExportacion> ExportRepo,
                              IRepository<FacturaElectronicaCompra> PurchaseRepo)
        {
            this.InvoiceRepository = InvoiceRepo;
            this.TiquetRepository = TiqueteRepo;
            this.CreditMemoRepository = CreditRepo;
            this.DebitMemoRepository = DebitRepo;
            this.ExportInvoiceRepository = ExportRepo;
            this.PurchaseInvoiceRepository = PurchaseRepo;
        }
        #endregion 

        #region Public Methods
        public bool SyncDocument(IDocCR document)
        {
            switch (document.XmlnsCR)
            {
                case XmlnsCR.FacturaElectronicaV43:
                    return InvoiceRepository.Save((FacturaElectronica)document);
                case XmlnsCR.TiqueteV43:
                    return TiquetRepository.Save((TiqueteElectronico)document);
                case XmlnsCR.NotaCreditoV43:
                    return CreditMemoRepository.Save((NotaCreditoElectronica)document);
                case XmlnsCR.NotaDebitoV43:
                    return DebitMemoRepository.Save((NotaDebitoElectronica)document);
                case XmlnsCR.FacturaElectronicaExportacionV43:
                    return ExportInvoiceRepository.Save((FacturaElectronicaExportacion)document);
                case XmlnsCR.FacturaElectronicaCompraV43:
                    return PurchaseInvoiceRepository.Save((FacturaElectronicaCompra)document);
                default:
                    throw new NotImplementedException(String.Format(Messages.NSInvalidType));
            }
        }
        #endregion
    }
}
