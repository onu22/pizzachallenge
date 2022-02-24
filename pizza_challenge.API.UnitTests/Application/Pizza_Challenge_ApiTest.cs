using Moq;
using Xunit;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using pizza.Domain.AggregateModel.OrderAggregate;
using pizza_challenge.Model;
using pizza_challenge.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace pizza_challenge.API.UnitTests.Application
{
    public class Pizza_Challenge_ApiTest
    {

        private readonly Mock<IOrderRepository> _orderRepository;

        public Pizza_Challenge_ApiTest()
        {
            _orderRepository = new Mock<IOrderRepository>();
        }

        [Fact]
        public async Task Create_Order_success()
        {
            //Arrange
            OrderCreateModel fakeOrderModel = GetFakeOrderModel() ;
            Order OrderData = GetFakeOrderData();

            _orderRepository.Setup(x => x.Add(OrderData));


            var subscriptionController = new OrderController(_orderRepository.Object);
            //Act
            var actionResult = await subscriptionController.Create(fakeOrderModel) as CreatedResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.Created);
        }


        private OrderCreateModel GetFakeOrderModel()
        {
            var order1 = new OrderCreateModel();
            order1.CustomerId = 1;
            order1.OrderItemModels.Add( new OrderItemModel() { PizzaName ="test pizza", Price = 125, PizzaId =5 });
            return order1;
        }

        private Order GetFakeOrderData()
        {
            var order = new Order(1);

            order.AddOrderItem(100, 2, "pizza 1");
            return order;
        }


    }
}
