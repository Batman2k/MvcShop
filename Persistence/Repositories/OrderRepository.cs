using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RapidMountain.Core.Dtos;
using RapidMountain.Core.Models;
using RapidMountain.Core.Repositories;

namespace RapidMountain.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IApplicationDbContext _context;

        public OrderRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public Order GetOrderByUserIdAndId(string userId, int id)
        {
            return _context.Orders
                .Include(o => o.OrderAddresses)
                .Include(o => o.OrderProducts)
                .FirstOrDefault(o => (o.Id == id) && (o.UserId == userId));
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<OrderDto> GetOrderDtosByUserId(string userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderDto
                {
                    OrderId = o.Id,
                    OrderStatus = o.OrderStatus,
                    TrackingNumber = o.TrackingNumber,
                    DatePlaced = o.DatePlaced,
                    TotalSum = o.OrderProducts.Select(op => op.Amount + op.Price).Sum()
                })
                .ToList();
        }

        public List<OrderDto> GetAllUnsentOrderDtos()
        {
            return _context.Orders
                .Where(o => o.TrackingNumber == null)
                .Select(o => new OrderDto
                {
                    OrderId = o.Id,
                    OrderStatus = o.OrderStatus,
                    TrackingNumber = o.TrackingNumber,
                    DatePlaced = o.DatePlaced,
                    TotalSum = o.OrderProducts.Select(op => op.Amount + op.Price).Sum()
                })
                .ToList();
        }

        public List<OrderDto> GetAllOrderDtos()
        {
            return _context.Orders
                .Select(o => new OrderDto
                {
                    OrderId = o.Id,
                    OrderStatus = o.OrderStatus,
                    TrackingNumber = o.TrackingNumber,
                    DatePlaced = o.DatePlaced,
                    TotalSum = o.OrderProducts.Select(op => op.Amount + op.Price).Sum()
                })
                .ToList();
        }
    }
}