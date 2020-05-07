using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IRestaurantMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenusForRestaurant(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
