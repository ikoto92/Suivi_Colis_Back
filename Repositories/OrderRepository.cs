using Microsoft.EntityFrameworkCore;
using Suivi_Colis_Back.Data;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

      
        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.Id == id); 
        }

        // Recherche par trackId (string)
        public Order GetOrderById(string trackId)
        {
            return _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.TrackId == trackId);  
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .ToList();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
