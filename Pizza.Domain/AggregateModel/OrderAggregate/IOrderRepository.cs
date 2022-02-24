using System.Collections.Generic;
using System.Threading.Tasks;
using pizza.Domain.SeedWork;

namespace pizza.Domain.AggregateModel.OrderAggregate
{

    public interface IOrderRepository : IRepository<Order>
    {

        Order Add(Order order);

        void Update(Order order);

        Task<IEnumerable<Order>> GetAllAsync();

        void Delete(Order order);

    }


}
