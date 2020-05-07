using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Constants;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Domain;
using SocietyPass.Mobile.Services.Repositories.Extensions;
using SocietyPass.Mobile.Services.Utility;

namespace SocietyPass.Mobile.Services.Repositories
{
    public class RestaurantMenuRepository : BaseRepository, IRestaurantMenuRepository
    {

        public RestaurantMenuRepository(IWebApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<IEnumerable<Menu>> GetAllMenusForRestaurant(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                .Append(ApiConstants.RestaurantsGetAll);

            try
            {
                //TODO: Transfer to cloud data service
                var result = new Utility.DataFacade().GetMenusByRestId(restaurantId);

                // var result = await _apiClient.GetAsync<IEnumerable<RestaurantListDto>>(string.Format(url.ToString()));

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
    }
}
