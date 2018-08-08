using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Collection.DSL;
using Collection.DAL;
using System.Net.Http;
using System.Net;

namespace Collection.APIs
{
    public class CustomerAPI : ApiController
    {
        CustomerDSL c = new CustomerDSL();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(c.GetCustomers());
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage addCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                c.InsertCustomer(customer);
                c.CommitCustomer();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            
              return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Server failed to save data");
           
        }
        
    }
}
