using Suivi_Colis_Back.DTOs;

namespace Suivi_Colis_Back.Repositories
{
    public interface IOrderService
    {
        OrderDto GetOrderById(int id);
        IEnumerable<OrderDto> GetAllOrders();
        void AddOrder(CreateOrderDto dto);
        void UpdateOrder(int id, UpdateOrderDto dto);
        void DeleteOrder(int id);
    }
}
