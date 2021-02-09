using IceCream.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models
{
    public class OrderCreate
    {
        public int CustomerID { get; set; }
        public int FlavorID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
