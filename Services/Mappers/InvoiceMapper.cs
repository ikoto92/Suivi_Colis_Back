using iText.Commons.Actions.Data;
using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Mappers
{
    public interface IInvoiceMapper
    {
        InvoiceDTO MapOrderToInvoiceDto(Order order);
    }

    public class InvoiceMapper : IInvoiceMapper
    {
        public InvoiceDTO MapOrderToInvoiceDto(Order order)
        {
            
            DateTime? deliveryDate = order.Status == OrderStatus.Delivered ? DateTime.Now : (DateTime?)null;

            int quantity = 1;

            return new InvoiceDTO
            {
                Id = order.Id,
                InvoiceNumber = GenerateInvoiceNumber(order), 
                Amount = order.Product.Price * quantity, 
                Date = DateTime.Now, 

                Order = new OrderDTOs
                {
                    Id = order.Id,
                    TrackId = order.TrackId,
                    Status = order.Status
                },

                Product = new ProductDTO
                {
                    Id = order.Product.Id,
                    Name = order.Product.Name,
                    Price = order.Product.Price
                },

                Customer = new CustomerDTO
                {
                    Id = order.Customer.Id,
                    Name = order.Customer.Name,
                    Email = order.Customer.Email
                },
                OrderStatus = order.Status
            };
        }
        private string GenerateInvoiceNumber(Order order)
        {
            return $"INV-{order.Id}-{DateTime.Now.Year}"; 
        }
    }

    public class CustomerDTO : Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
