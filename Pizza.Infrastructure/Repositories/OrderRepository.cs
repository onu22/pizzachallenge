using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pizza.Domain.AggregateModel.OrderAggregate;

namespace Pizza.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaContext _context;
        public OrderRepository(PizzaContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(x => x.OrderItems).ToListAsync();
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
