using System;
using System.Collections.Generic;
using System.Linq;
using pizza.Domain.AggregateModel.OrderAggregate;
using Xunit;


namespace pizza_challenge.API.UnitTests.Domain
{
    public class OrderAggregateTest
    {
        public OrderAggregateTest(){}


        [Fact]
        public void Create_Order_fail_When_Customerid_Is_Invalid()
        {
            int customerid = 0;
            //Act - Assert
            Assert.Throws<ArgumentNullException>(() => new Order(customerid));
        }


        [Fact]
        public void Order_should_return_accurate_totalAmount()
        {
            IEnumerable<Order> orders = GetFakeOrderData();

            //Act - Assert
            Assert.Equal(300, orders.First().GetTotalAmount());
        }



        private IEnumerable<Order> GetFakeOrderData()
        {
            var order1 = new Order(1);
            var order2 = new Order(2);

            order1.AddOrderItem(100, 2, "pizza 1");
            order1.AddOrderItem(200, 2, "pizza 1.1");

            order2.AddOrderItem(300, 2, "pizza 2");
            order2.AddOrderItem(400, 2, "pizza 2.2");
            return new List<Order>()
            {
                order1,
                order2,
            };
        }

    }
}
