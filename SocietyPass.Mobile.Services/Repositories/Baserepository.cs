using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Polly;
using SocietyPass.Mobile.Services.Contracts.API;

namespace SocietyPass.Mobile.Services.Repositories
{
    public class BaseRepository
    {
        protected readonly IWebApiClient _apiClient;

        public BaseRepository(IWebApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        protected async Task ExecuteRemoteRequest(Func<Task> action)
        {
            await Policy
                .Handle<WebException>(ex => { Debug.WriteLine($"{ ex.GetType().Name + " : " + ex.Message}"); return true; })
                .WaitAndRetryAsync
                (
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(action).ConfigureAwait(false);
        }

        protected async Task<TResult> ExecuteRemoteRequest<TResult>(Func<Task<TResult>> action)
        {
            TResult result = default(TResult);

            result = await Policy
                .Handle<Extensions.HttpResponseException>(ex => throw ex)
                .Or<WebException>(ex => { Debug.WriteLine($"{ ex.GetType().Name + " : " + ex.Message}"); return true; })
                .WaitAndRetryAsync
                (
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(action).ConfigureAwait(false);

            return result;
        }
    }
}