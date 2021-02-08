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
        public IEnumerable<OrderListItem> GetOrder()
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
                        }
                        );
                return query.ToArray();
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

        public OrderCreateModel GetOneOrder(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders
                    .Single(c => c.OrderID == id);
                return
                    new OrderCreateModel
                    {
                        OrderID = entity.OrderID,
                        CustomerID = entity.CustomerID,
                        Customer = entity.Customer,
                        ListOfFlavors = entity.ListOfFlavors
                    };
            }
        }
        public IEnumerable<FlavorListItem> GetAllFlavorsByOrder(int orderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx.Orders.Single(o => o.OrderID == orderID).ListOfFlavors
                    .Select(e => new FlavorListItem
                    {
                        FlavorName = e.FlavorName,
                        FlavorDesc = e.FlavorDesc,
                        FlavorID = e.FlavorID
                    }
                        );
                return foundItems.ToArray();
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
