using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Models;

namespace Suivi_Colis_Back.Services
{
    public interface IOrderMapper
    {
        OrderDto MapToDto(Order order);
        Order MapToEntity(CreateOrderDto dto);
    }
}
