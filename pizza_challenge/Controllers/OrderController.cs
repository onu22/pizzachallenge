using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizza.Domain.AggregateModel.OrderAggregate;
using pizza_challenge.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizza_challenge.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> Get()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(new OrderModel(orders).MapToOrderViewModels());
        }

      }
}
