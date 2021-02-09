using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models.CustomerAddressModels
{
   public class CAddressListItem
    {
        public int CustomerAddressID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetOne { get; set; }
        public int Zipcode { get; set; }
    }
}
