using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.DATA
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Flavor> ListOfFlavors { get; set; }

        public Order()
        {
            ListOfFlavors = new HashSet<Flavor>();
        }

    }
}
