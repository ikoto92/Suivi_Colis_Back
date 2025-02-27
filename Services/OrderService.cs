﻿using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Models;
using Suivi_Colis_Back.Repositories;

namespace Suivi_Colis_Back.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderMapper _mapper;

        public OrderService(IOrderRepository repository, IOrderMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Recherche par trackId (string)
        public OrderDto GetOrderById(string trackId)
        {
            var order = _repository.GetOrderById(trackId);
            return order == null ? null : _mapper.MapToDto(order);
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _repository.GetAllOrders();
            return orders.Select(_mapper.MapToDto);
        }

        public void AddOrder(CreateOrderDto dto)
        {
            var order = _mapper.MapToEntity(dto);
            _repository.AddOrder(order);
        }

        // Mise à jour de la commande par id (int)
        public void UpdateOrder(int id, UpdateOrderDto dto)
        {
            var order = _repository.GetOrderById(id);  
            if (order == null) return;

            order.Status = dto.Status;
            _repository.UpdateOrder(order);
        }

        // Suppression de la commande par id (int)
        public void DeleteOrder(int id)
        {
            _repository.DeleteOrder(id);
        }
    }
}
