using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Collection.DSL;
using System.Net.Http;

namespace Collection.APIs
{
    public class CustomerAPI : ApiController
    {
        CustomerDSL c = new CustomerDSL();
        //public HttpResponseMessage Post(Customer customer)
        //{
        //    HttpResponseMessage result;
        //    if (ModelState.IsValid)
        //    {
        //        c.InsertCustomer(customer);
        //        c.CommitCustomer();
        //       return  this.Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest, "Server failed to save data");
        //    }
        //    return result;
        //}
    }
}
