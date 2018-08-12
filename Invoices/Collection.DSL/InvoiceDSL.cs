using Collection.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;

 public class InvoiceDSL
    {

        InvoiceRepo repo = new InvoiceRepo();

    public IEnumerable<Invoice> GetInvoices()
    {
        var list = repo.GetInvoices();
        return list;

    }
    public Invoice GetInvoiceByID(int id)

    {
        var invoice = repo.GetInvoiceByID(id);
        return invoice;
    }

    public void InsertInvoice(Invoice invoice)
    {
        
        repo.InsertInvoice(invoice);
    }
    public void DeleteInvoice(int id)
    {
        repo.DeleteInvoice(id);
    }

    public void UpdateInvoice(Invoice invoice)
    {
        repo.UpdateInvoice(invoice);
    }
    public void CommitInvoice()
    {
        repo.CommitInvoice();
    }
}

