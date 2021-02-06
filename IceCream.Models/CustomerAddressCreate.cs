﻿using IceCream.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models
{
    public class CustomerAddressCreate
    {
        public int CustomerAddressID { get; set; }
        public virtual Customer Customer { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}
