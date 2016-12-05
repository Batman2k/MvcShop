using System.Collections.Generic;
using RapidMountain.Core.Dtos;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetOrderByUserIdAndId(string userId, int id);
        Order GetOrderById(int id);
        List<OrderDto> GetOrderDtosByUserId(string userId);
        List<OrderDto> GetAllUnsentOrderDtos();
        List<OrderDto> GetAllOrderDtos();
    }
}