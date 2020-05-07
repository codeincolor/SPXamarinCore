using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderByRestauranId(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Order>> GetOrderByUserId(int userId, CancellationToken cancellationToken = default(CancellationToken));
        Task<Order> GetOrderById(int orderId, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default(CancellationToken));
    }
}
