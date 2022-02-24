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

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(OrderCreateModel model)
        {
            //typically, i would not do this here.
            Order order = new Order(model.CustomerId);
            foreach (var item in model.OrderItemModels)
            {
                order.AddOrderItem(item.Price, item.PizzaId,item.PizzaName);
            }

            // i would use unity of work
            await _orderRepository.Add(order);

            return Created($"/api/v1/Order/{order.Id}", model);
        }



    }
}
