using Suivi_Colis_Back.DTOs;

namespace Suivi_Colis_Back.Services
{
    public interface IOrderService
    {
        OrderDto GetOrderById(string trackId);  // Recherche par trackId (string)
        IEnumerable<OrderDto> GetAllOrders();
        void AddOrder(CreateOrderDto dto);
        void UpdateOrder(int id, UpdateOrderDto dto);  // Mise à jour par Id (int)
        void DeleteOrder(int id);  // Suppression par Id (int)
    }
}
