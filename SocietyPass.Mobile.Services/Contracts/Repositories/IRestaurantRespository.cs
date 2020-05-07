using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IRestaurantRespository
    {
        Task<IEnumerable<RestaurantListDto>> GetAllRestaurantsForList(CancellationToken cancellationToken = default(CancellationToken));
        Task<Restaurant> GetRestaurantById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
    }
}