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
        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new CustomerService();
            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetAll()
        {
            CustomerService service = new CustomerService();
            var customers = service.GetAllCustomers();
            return Ok(customers);
        }

        public IHttpActionResult Get(int id)
        {
            var service = new CustomerService();
            var customer = service.GetOneCustomer(id);
            return Ok(customer);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new CustomerService();
            service.DeleteCustomer(id);
            return Ok();
        }
    }
}
