using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.DTOs
{
    public class CreateOrderDto
    {
        public string TrackId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }

    public class UpdateOrderDto
    {
        public OrderStatus Status { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public string TrackId { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
    }

    public class OrderDTO
    {
        public int Id { get; set; }
        public string TrackId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
