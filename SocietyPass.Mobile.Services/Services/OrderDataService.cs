using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using SocietyPass.Mobile.Services.Contracts.Repositories;

namespace SocietyPass.Mobile.Services.Services
{
    public class OrderDataService : IOrderDataService
    {
        public readonly IOrderRepository _orderRepository;

        public async Task<IEnumerable<Order>> GetOrderByRestauranIdAsync(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _orderRepository.GetOrderByRestauranId(restaurantId, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetOrderByUserId(int userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _orderRepository.GetOrderByUserId(userId, cancellationToken);
        }

        public async Task<Order> GetOrderById(int orderId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _orderRepository.GetOrderById(orderId, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _orderRepository.GetOrders(cancellationToken);
        }

        public Task<Order> PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> AddOrderItem(OrderItem orderItem, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
