using IceCream.DATA;
using IceCream.Models;
using IceCream.Models.CustomerAddressModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Service
{
    public class CustomerAddressService
    {
        public bool CreateCustomerAddress(CAddressCreate model,int customerID)
        {
            var entity = new CustomerAddress()
            {
                CustomerAddressID = customerID,
                StreetOne = model.StreetOne,
                StreetTwo = model.StreetTwo,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                Country = model.Country,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomerAddresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CAddressListItem> GetAllCustomerAddresses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CustomerAddresses
                    .Select(
                        e => new CAddressListItem
                        {
                            CustomerAddressID = e.CustomerAddressID,
                            FirstName = e.Customer.FirstName,
                            LastName = e.Customer.LastName,
                            StreetOne = e.StreetOne,
                            Zipcode = e.Zipcode,
                        }
                        );
                return query.ToArray();
            }
        }
        public CAddressListItem GetOneCustomerAddress(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = ctx.CustomerAddresses
                    .Single(c => c.CustomerAddressID == id);
                return
                    new CAddressListItem
                    {
                        CustomerAddressID = model.CustomerAddressID,
                        FirstName = model.Customer.FirstName,
                        LastName = model.Customer.LastName,
                        StreetOne = model.StreetOne,
                        Zipcode = model.Zipcode,
                    };
            }
        }
        public bool DeleteCustomerAddress(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CustomerAddresses.Single(c => c.CustomerAddressID == id);
                ctx.CustomerAddresses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
