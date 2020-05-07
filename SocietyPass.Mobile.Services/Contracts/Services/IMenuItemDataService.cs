using SocietyPass.Mobile.Services.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.Services
{
    public interface IMenuItemDataService
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
        Task<MenuItem> GetMenuItemById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
    }
}