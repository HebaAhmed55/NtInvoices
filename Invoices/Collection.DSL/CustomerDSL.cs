using Collection.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;


namespace Collection.DSL
{
    public class CustomerDSL
    {
        CustomerRepo repo = new CustomerRepo();

        public IEnumerable<Customer> GetCustomers()
        {
            var list = repo.GetCustomers();
            return list;

        }
        public Customer GetCustomerByID(int id)

        {
            var customer = repo.GetCustomerByID(id);
            return customer;
        }

        public void InsertCustomer(Customer customer)
        {
            //List<Customeres> ListCustomer = GetCustomerList();
            //int Count = ListCustomer.Count();
            //foreach (var o in ListCustomer)
            //{
            //    if (o.CustomerNo >= Count)
            //    {
            //        Count = o.CustomerNo + 1;
            //    }
            //}
            repo.InsertCustomer(customer);
        }
        public void DeleteCustomer(int id)
        {
            repo.DeleteCustomer(id);
        }
        
        public void UpdateCustomer(Customer customer)
        {
            repo.UpdateCustomer(customer);
        }
        public void CommitCustomer()
        {
            repo.CommitCustomer();
        }
    }
}
