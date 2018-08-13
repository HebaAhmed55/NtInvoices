using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Collection.DAL;

namespace Collection.Repository
{
    public class InvoiceRepo
    {
        public static InvoicesEntities2 context2 = new InvoicesEntities2();

        public List<Invoice> GetInvoices()
        {
            var invoices = context2.Invoices.Include(i => i.Comment).Include(i => i.Customer);
            return context2.Invoices.ToList();
        }

        public Invoice GetInvoiceByID(int id)
        {
            return context2.Invoices.Find(id);
        }

        public void InsertInvoice(Invoice invoice)
        {

            context2.Invoices.Add(invoice);
        }

        public void DeleteInvoice(int InvoiceId)
        {
            Invoice invoice = context2.Invoices.Find(InvoiceId);
            context2.Invoices.Remove(invoice);

        }


        public void UpdateInvoice(Invoice invoice)
        {

            var c = context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId);

            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).IssueDate= invoice.IssueDate;
            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).Amount = invoice.Amount;
            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).CollectDate = invoice.CollectDate;
            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).ActCollectDate = invoice.ActCollectDate;
            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).Suspended = invoice.Suspended;
            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).Collected = invoice.Collected;
            context2.Invoices.FirstOrDefault(d => d.InvoiceId == invoice.InvoiceId).Cus_id = invoice.Cus_id;
            CommitInvoice();
        }

        public void CommitInvoice()
        {
            context2.SaveChanges();
        }
    }
}
