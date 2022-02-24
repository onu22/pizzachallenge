using System;
using System.Collections.Generic;
using System.Linq;
using pizza.Domain.SeedWork;

namespace pizza.Domain.AggregateModel.OrderAggregate
{

    public class Order : Entity, IAggregateRoot
    {
        public int CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        protected Order() {}
        public Order(int customerId)
        {
            CustomerId = customerId > 0 ? customerId : throw new ArgumentNullException(nameof(customerId));
            OrderDate = DateTime.UtcNow;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(decimal price, int pizzaId, string pizzaName)
        {
             var orderItem = new OrderItem(price, pizzaId, pizzaName);
             _orderItems.Add(orderItem);
        }


        public decimal GetTotalAmount()
        {
            var amount = _orderItems.Sum(o => o.GetPrice());

            return amount;
        }

    }


}
