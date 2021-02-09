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
    public class OrderController : ApiController
    {

        public IHttpActionResult Post(OrderCreate order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new OrderService();
            if (!service.CreateOrder(order))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Post(int orderID, int flavorID)
        {
            var service = new OrderService();
            service.AddFlavorToOrder(flavorID, orderID);
            return Ok();
        }

        public IHttpActionResult GetAll()
        {
            OrderService service = new OrderService();
            var order = service.GetAllOrders();
            return Ok(order);
        }

        public IHttpActionResult Get(int id)
        {
            var service = new OrderService();
            var order = service.GetOneOrder(id);
            return Ok(order);
        }
        public IHttpActionResult Delete(int id)
        {
            var service = new OrderService();
            service.DeleteOrder(id);
            return Ok();
        }
    }
}
