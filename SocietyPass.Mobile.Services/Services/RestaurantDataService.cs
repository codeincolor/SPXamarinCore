using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Domain;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Services
{
    public class RestaurantDataService: IRestaurantDataService
    {
        private readonly IRestaurantRespository _restaurantRespository;

        public RestaurantDataService(IRestaurantRespository restaurantRespository)
        {
            _restaurantRespository = restaurantRespository;
        }

        public async Task<IEnumerable<RestaurantListDto>> GetAllRestaurantsForList(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _restaurantRespository.GetAllRestaurantsForList(cancellationToken);
        }

        public async Task<Restaurant> GetRestaurantById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _restaurantRespository.GetRestaurantById(restaurantId, cancellationToken);
        }

        public Task<IEnumerable<Menu>> GetRestaurantMenusById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}