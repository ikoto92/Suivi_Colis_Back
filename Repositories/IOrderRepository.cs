using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrderById(string trackId); // Modification du paramètre en string
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrderById(int id);
    }
}
