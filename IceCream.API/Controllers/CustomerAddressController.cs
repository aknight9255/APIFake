using IceCream.DATA;
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
    public class CustomerAddressController : ApiController
    {
        public IHttpActionResult Post(CAddressCreate customerAddress, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new CustomerAddressService();
            if (!service.CreateCustomerAddress(customerAddress, id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetAll()
        {
            CustomerAddressService service = new CustomerAddressService();
            var customers = service.GetAllCustomerAddresses();
            return Ok(customers);
        }

        public IHttpActionResult Get(int id)
        {
            var service = new CustomerAddressService();
            var customer = service.GetOneCustomerAddress(id);
            return Ok(customer);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new CustomerAddressService();
            service.DeleteCustomerAddress(id);
            return Ok();
        }
    }
}
