using iText.Commons.Actions.Data;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; } 
        public string InvoiceNumber { get; set; } 
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; } 
        public OrderDto Order { get; set; }
        public ProductData Product { get; set; }
        public Customer Customer { get; set; } 
        public OrderStatus OrderStatus { get; set; } 
    }

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static implicit operator ProductData(ProductDTO v)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderDTOs : OrderDto
    {
        public int Id { get; set; }
        public string TrackId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
