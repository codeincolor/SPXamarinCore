using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Domain;
using SocietyPass.Mobile.Services.Repositories.Extensions;

namespace SocietyPass.Mobile.Services.Repositories
{
    public class MenuItemRepository : BaseRepository, IMenuItemRepository
    {
       

        public MenuItemRepository(IWebApiClient apiClient) : base(apiClient)
        {
        }
        public async Task<MenuItem> GetMenuItemById(int menuItemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var result = new Utility.DataFacade().GetMenuItemById(menuItemId);

                return result;
            }
            catch (HttpResponseException e)
            {
                //TODO: check unauthorized exceptions here
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
            
        }

        public Task<IEnumerable<MenuItem>> GetMenuItemsById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}