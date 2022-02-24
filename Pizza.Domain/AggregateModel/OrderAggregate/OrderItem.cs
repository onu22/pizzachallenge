using System;
using pizza.Domain.SeedWork;

namespace pizza.Domain.AggregateModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string PizzaName { get; private set; }
        public decimal Price { get; private set; }
        public int PizzaId { get; private set; }

        protected OrderItem() { }
        public OrderItem(decimal price, int pizzaId, string pizzaName)
        {
            if (price <= 0){ throw new ArgumentException("Price cannot be zero"); }
            PizzaId = pizzaId;
            PizzaName = pizzaName;
            Price = price;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
}
