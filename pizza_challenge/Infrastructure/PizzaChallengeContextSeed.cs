using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pizza.Domain.AggregateModel.OrderAggregate;
using Pizza.Infrastructure;

namespace pizza_challenge.API.Infrastructure
{
    public class PizzaChallengeContextSeed
    {
        public async Task SeedAsync(PizzaContext context)
        {
            using (context)
            {
                if (!context.Orders.Any())
                {
                    await context.Orders.AddRangeAsync(GetOrders());
                }
                await context.SaveChangesAsync();
            }

        }

        private IEnumerable<Order> GetOrders()
        {
            var order1 = new Order(1);
            var order2 = new Order(2);

            order1.AddOrderItem(150, 2, "pizza 1");
            order1.AddOrderItem(170, 2, "pizza 1.1");

            order2.AddOrderItem(250, 2, "pizza 2");
            order2.AddOrderItem(270, 2, "pizza 2.2");
            return new List<Order>()
            {
                order1,
                order2,
            };
        }
    }
}
