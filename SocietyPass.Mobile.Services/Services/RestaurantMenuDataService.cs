using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Repositories;

namespace SocietyPass.Mobile.Services.Services
{
    public class RestaurantMenuDataService : IRestaurantMenuDataService
    {
        private readonly IRestaurantMenuRepository _menuRespository;

        public RestaurantMenuDataService(IRestaurantMenuRepository menuRespository)
        {
            _menuRespository = menuRespository;
        }
        public Task<IEnumerable<Menu>> GetRestaurantMenusById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
           return  _menuRespository.GetAllMenusForRestaurant(restaurantId);
        }
    }
}
