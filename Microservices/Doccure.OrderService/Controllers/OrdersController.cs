using Doccure.OrderService.Dtos.OrderDtos;
using Doccure.OrderService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderService;
        public OrdersController(IOrderServices orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var values = await _orderService.GetAllOrderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var value = await _orderService.GetByIdOrderAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderService.CreateOrderAsync(createOrderDto);
            return Ok("Sipariş başarıyla oluşturuldu");
        }
    }
}
