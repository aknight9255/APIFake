using IceCream.DATA;
using IceCream.Models;
using IceCream.Models.Flavor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Service
{
    public class OrderService
    {
        public bool CreateOrder(OrderCreate order)
        {
            var entity = new Order()
            {
                CreatedUtc = DateTimeOffset.Now,
                CustomerID = order.CustomerID
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
        public IEnumerable<OrderListItem> GetAllOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Orders
                    .Select(
                        e => new OrderListItem
                        {
                            OrderID = e.OrderID,
                            CustomerID = e.CustomerID,
                            FirstName = e.Customer.FirstName,
                            ZipCode = e.Customer.CAddress.Zipcode,
                            FlavorCount = e.ListOfFlavors.Count
                        }
                        );
                return query.ToArray();
            }
        }
        public OrderListItem GetOneOrder(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders
                    .Single(c => c.OrderID == id);
                return
                    new OrderListItem
                    {
                        OrderID = entity.OrderID,
                        CustomerID = entity.CustomerID,
                        FirstName = entity.Customer.FirstName,
                        ZipCode = entity.Customer.CAddress.Zipcode,
                        FlavorCount = entity.ListOfFlavors.Count
                    };
            }
        }
        public bool DeleteOrder(int orderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders.Single(c => c.OrderID == orderID);
                ctx.Orders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
