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

    public List<Invoice> GetInvoices()
    {
        var list2 = repo.GetInvoices();
        return list2;

    }
    public Invoice GetInvoiceByID(int id)

    {
        var invoice = repo.GetInvoiceByID(id);
        return invoice;
    }

    public void InsertInvoice(Invoice invoice)
    {
        List<Invoice> list = repo.GetInvoices();
        int Count = list.Count();
        foreach(var o in list)
        {
            if(o.InvoiceNo >= Count) { Count = o.InvoiceNo + 1; }
        }
        invoice.InvoiceNo = Count;

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

