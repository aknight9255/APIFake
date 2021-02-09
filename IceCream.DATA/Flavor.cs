using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.DATA
{
    public class Flavor
    {
        [Key]
        public int FlavorID { get; set; }
        public string FlavorName { get; set; }
        public string FlavorDesc { get; set; }

        public virtual ICollection<Order> ListOfOrders { get; set; }

        public Flavor()
        {
            ListOfOrders = new HashSet<Order>();
        }
    }
}
