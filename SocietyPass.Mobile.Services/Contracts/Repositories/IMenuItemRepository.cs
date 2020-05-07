using SocietyPass.Mobile.Services.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
        Task<MenuItem> GetMenuItemById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken));
    }
}