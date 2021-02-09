using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.DATA
{
    public class CustomerAddress
    {
        [ForeignKey("Customer")]
        public int CustomerAddressID { get; set; }
        public virtual Customer Customer { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
    }
}
