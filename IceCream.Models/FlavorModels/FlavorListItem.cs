using IceCream.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models.Flavor
{
    public class FlavorListItem
    {
        public int FlavorID { get; set; }
        public string FlavorName { get; set; }
        public string FlavorDesc { get; set; }
        public virtual ICollection<Order> ListOfOrders { get; set; }
    }
}
