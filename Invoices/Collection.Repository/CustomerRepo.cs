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

    public class CustomerRepo
    {
         private InvoicesEntities context;
        


        public CustomerRepo()
        {
            context = new InvoicesEntities ();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer GetCustomerByID(int id)
        {
            return context.Customers.Find(id);
        }

        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void DeleteCustomer(int CustomerId)
        {
            Customer customer = context.Customers.Find(CustomerId);
            context.Customers.Remove(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void CommitCustomer()
        {
            context.SaveChanges();
        }

        //    private bool disposed = false;

        //    protected virtual void Dispose(bool disposing)
        //    {
        //        if (!this.disposed)
        //        {
        //            if (disposing)
        //            {
        //                context.Dispose();
        //            }
        //        }
        //        this.disposed = true;
        //    }

        //    public void Dispose()
        //    {
        //        Dispose(true);
        //        GC.SuppressFinalize(this);
        //    }
        //}
    }
}

