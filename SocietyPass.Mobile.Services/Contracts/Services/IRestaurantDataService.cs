using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Domain;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Contracts.Services
{
    public interface IRestaurantDataService
    {
        Task<IEnumerable<RestaurantListDto>> GetAllRestaurantsForList(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Restaurant> GetRestaurantById(int restaurantId,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Menu>> GetRestaurantMenusById(int restaurantId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}