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
        
        public static InvoicesEntities2 context = new InvoicesEntities2();
        
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

            var c = context.Customers.FirstOrDefault(d => d.CustomerId == customer.CustomerId);

            context.Customers.FirstOrDefault(d => d.CustomerId == customer.CustomerId).CustomerName = customer.CustomerName;
            context.Customers.FirstOrDefault(d => d.CustomerId == customer.CustomerId).Active = customer.Active;
            //context.Entry(customer).State = EntityState.Detached;
            //context.Entry(customer).State = EntityState.Modified;
            CommitCustomer();
        }

        public void CommitCustomer()
        {
            context.SaveChanges();
        }

        
    }
}

