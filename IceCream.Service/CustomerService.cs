using IceCream.DATA;
using IceCream.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Service
{
    public class CustomerService
    {
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItem> GetAllCustomers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Select(
                        e => new CustomerListItem
                        {
                            CustomerID = e.CustomerID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                        }
                        );
                return query.ToArray();
            }
        }
        public CustomerListItem GetOneCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers
                    .Single(c => c.CustomerID == id);
                return
                    new CustomerListItem
                    {
                        CustomerID = entity.CustomerID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                    };
            }
        }
        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(c => c.CustomerID == id);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
