using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Services
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                TrackId = order.TrackId,
                Status = order.Status.ToString(),
                ProductName = order.Product?.Name,
                CustomerName = order.Customer?.Name
            };
        }

        public Order MapToEntity(CreateOrderDto dto)
        {
            return new Order
            {
                TrackId = dto.TrackId,
                Status = OrderStatus.Pending,
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId
            };
        }
    }
}
