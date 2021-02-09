using IceCream.DATA;
using IceCream.Models;
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
        public IHttpActionResult Post(FlavorCreate flavor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new FlavorService();
            if (!service.CreateFlavor(flavor))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetAll()
        {
            FlavorService service = new FlavorService();
            var flavor = service.GetAllFlavors();
            return Ok(flavor);
        }
  
        public IHttpActionResult Get(int id)
        {
            var service = new FlavorService();
            var flavor = service.GetOneFlavor(id);
            return Ok(flavor);
        }
        public IHttpActionResult Delete(int id)
        {
            var service = new FlavorService();
            service.DeleteFlavor(id);
            return Ok();
        }

    }
}

