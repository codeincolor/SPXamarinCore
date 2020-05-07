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
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(IWebApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<IEnumerable<Review>> GetAllReviewsForRestaurant(CancellationToken cancellationToken = new CancellationToken())
        {
            var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                .Append(ApiConstants.ReviewsByRestaurantId);

            try
            {
                //TODO: enable retry mechanism
                //var result = await ExecuteRemoteRequest(async () => await _apiClient.GetAsync<IEnumerable<Restaurant>>(string.Format(url.ToString()),
                //    cancellationToken));

                var result = await _apiClient.GetAsync<IEnumerable<Review>>(string.Format(url.ToString()));

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

        public async Task<Review> GetReviewById(int reviewId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                .Append(ApiConstants.ReviewsGetById).ToString();

            url = string.Format(url, reviewId.ToString());

            try
            {
                //TODO: enable retry mechanism
                //var result = await ExecuteRemoteRequest(async () => await _apiClient.GetAsync<IEnumerable<Restaurant>>(string.Format(url.ToString()),
                //    cancellationToken));

                var result = await _apiClient.GetAsync<Review>(string.Format(url.ToString()));

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

        public async Task<IEnumerable<Review>> GetReviewByRestId(int restId, CancellationToken cancellationToken = new CancellationToken())
        {
            var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                .Append(ApiConstants.RestaurantsGetAll);

            try
            {
                //TODO: Transfer to cloud data service
                var result = new Utility.DataFacade().GetReviewsByRestId(restId);

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
