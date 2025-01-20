using Suivi_Colis_Back.Models;
using Suivi_Colis_Back.Data;
using Microsoft.EntityFrameworkCore;

namespace Suivi_Colis_Back.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Order> GetOrderDetailsAsync(int orderId);
    }

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderDetailsAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
