using Collection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoices.ViewModels
{
    public class InvoiceViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

    }
}