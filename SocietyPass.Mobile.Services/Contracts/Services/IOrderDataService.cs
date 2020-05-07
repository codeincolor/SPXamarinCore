using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.Services
{
    public interface IOrderDataService
    {
        Task<IEnumerable<Order>> GetOrderByRestauranIdAsync(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Order>> GetOrderByUserId(int userId, CancellationToken cancellationToken = default(CancellationToken));
        Task<Order> GetOrderById(int orderId, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default(CancellationToken));
        Task<Order> PlaceOrder(Order order);
        Task<OrderItem> AddOrderItem(OrderItem orderItem, string userId);

    }
}
