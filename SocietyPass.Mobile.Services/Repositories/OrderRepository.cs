using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IWebApiClient apiClient) : base(apiClient)
        {
        }

        public Task<Order> GetOrderById(int orderId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrderByRestauranId(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrderByUserId(int userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
