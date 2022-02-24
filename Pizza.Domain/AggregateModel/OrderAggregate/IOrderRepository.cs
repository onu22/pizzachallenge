using System.Collections.Generic;
using System.Threading.Tasks;
using pizza.Domain.SeedWork;

namespace pizza.Domain.AggregateModel.OrderAggregate
{

    public interface IOrderRepository : IRepository<Order>
    {

        Task Add(Order order);

        Task Update(Order order);

        Task<IEnumerable<Order>> GetAllAsync();

        void Delete(Order order);

    }


}
