using IceCream.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models
{
    public class OrderListItem
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public int ZipCode { get; set; }
        public int FlavorCount { get; set; }
    }
}
