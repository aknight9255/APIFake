using IceCream.Models;
using IceCream.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IceCream.API.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CustomerService service = new CustomerService();
            var customers = service.GetCustomers();
            return Ok(customers);
        }

        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new CustomerService();
            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }
    }
}
