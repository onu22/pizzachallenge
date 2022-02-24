using System;
using System.Collections.Generic;
using pizza.Domain.AggregateModel.OrderAggregate;

namespace pizza_challenge.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemModel> OrderItemModels;
        public decimal TotalAmount { get; set; }

        private IEnumerable<Order> _orders;
        protected OrderModel()
        {
            OrderItemModels = new List<OrderItemModel>();
        }

        public OrderModel(IEnumerable<Order> orders) : this()
        {
            _orders = orders;
        }

        public List<OrderModel> MapToOrderViewModels()
        {
            List<OrderModel> models = new List<OrderModel>();
            foreach (var order in _orders)
            {
                OrderModel orderModel = new OrderModel() { OrderId = order.Id, CustomerId = order.CustomerId, OrderDate = order.OrderDate, TotalAmount = order.GetTotalAmount() };
                foreach (var item in order.OrderItems)
                {
                    orderModel.OrderItemModels.Add(new OrderItemModel() { PizzaName = item.PizzaName, Price = item.Price, PizzaId = item.PizzaId });
                }

                models.Add(orderModel);

            }

            return models;
        }

    }


    public class OrderItemModel
    {
        public string PizzaName { get; set; }
        public decimal Price { get; set; }
        public int PizzaId { get; set; }

    }


}
