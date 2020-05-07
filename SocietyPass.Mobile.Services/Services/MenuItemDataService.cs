using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Services
{
    public class MenuItemDataService : IMenuItemDataService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemDataService(IMenuItemRepository menuItemRespository)
        {
            _menuItemRepository = menuItemRespository;
        }

        public async Task<MenuItem> GetMenuItemById(int menuItemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _menuItemRepository.GetMenuItemById(menuItemId, cancellationToken);
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _menuItemRepository.GetMenuItemsById(restaurantId);
        }
    }
}
