using IceCream.Models.Flavor;
using IceCream.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IceCream.API.Controllers
{
    public class FlavorController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            FlavorService service = new FlavorService();
            var flavor = service.GetFlavor();
            return Ok(flavor);
        }

        public IHttpActionResult Post(FlavorCreate flavor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new FlavorService();
            if (!service.CreateFlavor(flavor))
                return InternalServerError();

            return Ok();
        }
    }
}

