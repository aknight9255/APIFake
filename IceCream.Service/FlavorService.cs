using IceCream.DATA;
using IceCream.Models.Flavor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Service
{
    public class FlavorService
    {
        public bool CreateFlavor(FlavorCreate model)
        {
            var entity = new Flavor()
            {
                FlavorName = model.FlavorName,
                FlavorDesc = model.FlavorDesc
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Flavors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FlavorListItem> GetFlavor()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Flavors
                    .Select(
                        e => new FlavorListItem
                        {
                            FlavorName = e.FlavorName,
                            FlavorDesc = e.FlavorDesc
                        }
                        );
                return query.ToArray();
            }
        }
        public FlavorCreate GetOneFlavor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Flavors
                    .Single(c => c.FlavorID == id);
                return
                    new FlavorCreate
                    {
                        FlavorID = entity.FlavorID,
                        FlavorName = entity.FlavorName,
                        FlavorDesc = entity.FlavorDesc
                    };
            }
        }
        public bool DeleteFlavor(int flavorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Flavors.Single(c => c.FlavorID == flavorId);
                ctx.Flavors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
