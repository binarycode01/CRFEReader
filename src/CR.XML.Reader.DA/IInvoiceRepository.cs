using CR.XML.Reader.Entities.XSD.v43.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.XML.Reader.DA
{
    public interface IInvoiceRepository
    {
        public void Save(FacturaElectronica invoice);
    }
}
