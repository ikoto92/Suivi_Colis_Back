using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Repositories;

namespace Suivi_Colis_Back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersControlle : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersControlle(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _service.GetOrderById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _service.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto dto)
        {
            _service.AddOrder(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderDto dto)
        {
            _service.UpdateOrder(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _service.DeleteOrder(id);
            return NoContent();
        }
    }
}
