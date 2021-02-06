using IceCream.DATA;
using IceCream.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Service
{
    public class OrderService
    {
        public bool CreateOrder(OrderCreateModel order)
        {
            var entity = new Order
            {
                CustomerID = order.CustomerID,
                Customer = order.Customer,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public void AddFlavorToOrder(int flavorID, int orderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundFlavor = ctx.Flavors.Single(f => f.FlavorID == flavorID);
                var foundOrder = ctx.Orders.Single(o => o.OrderID == orderID);
                foundOrder.ListOfFlavors.Add(foundFlavor);
                var testing = ctx.SaveChanges();
            }
        }

        public CustomerCreate GetOneOrder(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders
                    .Single(c => c.OrderID == id);
                return
                    new CustomerCreate
                    {
                        
                    };
            }
        }

        public bool DeleteCustomer(int customerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(c => c.CustomerID == customerID);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
