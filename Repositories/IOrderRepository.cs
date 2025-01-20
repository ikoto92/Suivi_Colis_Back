using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
