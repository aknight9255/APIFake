using IceCream.DATA;
using IceCream.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Service
{
    public class CustomerAddressService
    {
        public bool CreateCustomerAddress(CustomerAddressCreate model,int customerID)
        {
            var entity = new CustomerAddress()
            {
                CustomerAddressID = customerID,
                AddressOne = model.AddressOne,
                AddressTwo = model.AddressTwo,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                Country = model.Country,
                Email = model.Email
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerAddresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }



        public IEnumerable<CustomerAddressCreate> GetCustomerAddressAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CustomerAddresses
                    .Select(
                        e => new CustomerAddressCreate
                        {
                            CustomerAddressID = e.CustomerAddressID,
                            AddressOne = e.AddressOne,
                            AddressTwo = e.AddressTwo,
                            City = e.City,
                            State = e.State,
                            Zipcode = e.Zipcode,
                            Country = e.Country,
                            Email = e.Email
                        }
                        );
                return query.ToArray();
            }
        }

        public CustomerAddressCreate GetOneCustomerAddress(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = ctx.CustomerAddresses
                    .Single(c => c.CustomerAddressID == id);
                return
                    new CustomerAddressCreate
                    {
                        CustomerAddressID = model.CustomerAddressID,
                        AddressOne = model.AddressOne,
                        AddressTwo = model.AddressTwo,
                        City = model.City,
                        State = model.State,
                        Zipcode = model.Zipcode,
                        Country = model.Country,
                        Email = model.Email
                    };
            }
        }

        public bool DeleteCustomerAddress(int customerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CustomerAddresses.Single(c => c.CustomerAddressID == customerID);
                ctx.CustomerAddresses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
