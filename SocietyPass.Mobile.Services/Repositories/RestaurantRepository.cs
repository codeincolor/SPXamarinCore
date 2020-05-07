using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Constants;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Contracts.Domain;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Domain;
using SocietyPass.Mobile.Services.Repositories.Extensions;
using SocietyPass.Mobile.Services.Utility;

namespace SocietyPass.Mobile.Services.Repositories
{
    public class RestaurantRepository: BaseRepository, IRestaurantRespository
    {
        public RestaurantRepository(IWebApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<IEnumerable<RestaurantListDto>> GetAllRestaurantsForList(CancellationToken cancellationToken = new CancellationToken())
        {
            var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                .Append(ApiConstants.RestaurantsGetAll);

            try
            {
                //caching
                //TODO: enable retry mechanism
                //var result = await ExecuteRemoteRequest(async () => await _apiClient.GetAsync<IEnumerable<Restaurant>>(string.Format(url.ToString()),
                //    cancellationToken));
                var result = new Utility.DataFacade().GetRestaurants();
                
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

        public async Task<Restaurant> GetRestaurantById(int restaurantId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                .Append(ApiConstants.RestaurantsGetById).ToString();

            url = string.Format(url, restaurantId.ToString());

            try
            {
                //TODO: enable retry mechanism
                //var result = await ExecuteRemoteRequest(async () => await _apiClient.GetAsync<IEnumerable<Restaurant>>(string.Format(url.ToString()),
                //    cancellationToken));

                // var result = await _apiClient.GetAsync<Restaurant>(string.Format(url.ToString()));
                var result = new Utility.DataFacade().GetRestaurantById(restaurantId);

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