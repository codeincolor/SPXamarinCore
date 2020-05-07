using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Constants;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Repositories.ContentResolvers;
using SocietyPass.Mobile.Services.Repositories.Extensions;
using SocietyPass.Mobile.Services.Repositories.ResponseResolvers;
using SocietyPass.Mobile.Services.Utility;

namespace SocietyPass.Mobile.Services.Repositories.Client
{
    public class WebApiClient : IWebApiClient
    {
        private IHttpContentResolver _httpContentResolver;
        private IHttpResponseResolver _httpResponseResolver;
        private bool _isDisposed;
        private Lazy<HttpClient> _client;
        private readonly IOAuthService _OAuthService;

        public WebApiClient()
        {
            var baseUrl = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl).ToUri();

            _client = new Lazy<HttpClient>(() => new HttpClient());

        }

        /// <summary>
        /// Gets or sets the implementation of the <see cref="IHttpContentResolver"/> interface associated with the WebApiClient.
        /// </summary>
        /// <remarks>
        /// The <see cref="IHttpContentResolver"/> implementation is responsible for serializing content which needs to be send to the server
        /// using a HTTP POST or PUT request.
        ///
        /// When no other value is supplied the <see cref="WebApiClient"/> by default uses the <see cref="SimpleJsonContentResolver"/>. This resolver will
        /// try to serialize the content to a JSON message and returns the proper <see cref="System.Net.Http.HttpContent"/> instance.
        /// </remarks>
        public IHttpContentResolver HttpContentResolver
        {
            get => _httpContentResolver ?? (_httpContentResolver = new SimpleJsonContentResolver());
            set => _httpContentResolver = value;
        }

        /// <summary>
        /// Gets or sets the implementation of the <see cref="IHttpResponseResolver"/> interface associated with the WebApiClient.
        /// </summary>
        /// <remarks>
        /// The <see cref="IHttpResponseResolver"/> implementation is responsible for deserialising the <see cref="System.Net.Http.HttpResponseMessage"/>
        /// into the required result object.
        ///
        /// When no other value is supplied the <see cref="WebApiClient"/> by default uses the <see cref="SimpleJsonResponseResolver"/>. This resolver will
        /// assumes the response is a JSON message and tries to deserialize it into the required result object.
        /// </remarks>
        public IHttpResponseResolver HttpResponseResolver
        {
            get => _httpResponseResolver ?? (_httpResponseResolver = new SimpleJsonResponseResolver());
            set => _httpResponseResolver = value;
        }

        /// <summary>
        /// Gets or sets the accept header of the HTTP request. Default the accept header is set to "appliction/json".
        /// </summary>
        public string AcceptHeader { get; set; } = "application/json";

        public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Sends a GET request to the API
        /// </summary>
        /// <returns>TResult</returns>
        public async Task<TResult> GetAsync<TResult>(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = GetWebApiClient();
            SetHttpRequestHeaders(httpClient);

            var response = await httpClient.GetAsync(path, cancellationToken);
            
            return await HttpResponseResolver.ResolveHttpResponseAsync<TResult>(response);
        }

        /// <summary>
        /// Sends a GET request to the API
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = GetWebApiClient();

            SetHttpRequestHeaders(httpClient);

            var response = await httpClient.GetAsync(path, cancellationToken).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a POST request to the API
        /// </summary>
        public async Task PostAsync<TContent>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = GetWebApiClient();

            SetHttpRequestHeaders(httpClient);

            HttpContent httpContent = null;

            if (content != null)
            {
                httpContent = HttpContentResolver.ResolveHttpContent(content);
            }

            var response = await httpClient
                .PostAsync(path, httpContent, cancellationToken)
                .ConfigureAwait(false);

            await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a POST request to the API
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        public async Task<TResult> PostAsync<TContent, TResult>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = GetWebApiClient();

            SetHttpRequestHeaders(httpClient);

            HttpContent httpContent = null;

            if (content != null)
            {
                httpContent = HttpContentResolver.ResolveHttpContent(content);
            }

            var response = await httpClient
                .PostAsync(path, httpContent, cancellationToken)
                .ConfigureAwait(false);

            await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);

            return await HttpResponseResolver.ResolveHttpResponseAsync<TResult>(response).ConfigureAwait(false);
        }

        
        /// <summary>
        /// Sends a DELETE request to the API
        /// </summary>
        public async Task DeleteAsync<TContent>(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = GetWebApiClient();

            SetHttpRequestHeaders(httpClient);

            var response = await httpClient
                .DeleteAsync(path, cancellationToken)
                .ConfigureAwait(false);

            await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a PATCH request to the API
        /// </summary>
        public async Task PatchAsync<TContent>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken))
        {
            var httpClient = GetWebApiClient();

            SetHttpRequestHeaders(httpClient);

            HttpContent httpContent = null;

            if (content != null)
                httpContent = HttpContentResolver.ResolveHttpContent(content);

            var response = await httpClient
                .PatchAsync(path, httpContent, cancellationToken)
                .ConfigureAwait(false);

            await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the requested HttpClient with the correct priority
        /// </summary>
        private HttpClient GetWebApiClient()
        {
            return _client.Value;
        }

        /// <summary>
        /// Sets the RequestHeaders for the request on the HttpClient
        /// </summary>
        private async void SetHttpRequestHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            Headers.Clear();
            
            try
            {
                var bearerToken = await _OAuthService.GetToken();
                if (bearerToken == null)
                    return;
                Headers.Add("Authorization", string.Format("{0} {1}", "Bearer", bearerToken.Token));

                foreach (var header in Headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                _client.Value?.Dispose();
            }

            _client = null;

            _isDisposed = true;
        }
    }
}