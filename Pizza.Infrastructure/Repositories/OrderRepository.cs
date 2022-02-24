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

        //i would use unity of work
        public async Task Add(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(x => x.OrderItems).ToListAsync();
        }

        public async Task Update(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }

        public void Delete(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
