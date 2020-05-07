using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.API
{
    public interface IWebApiClient : IDisposable
    {
        string AcceptHeader { get; set; }
        IDictionary<string, string> Headers { get; }
        IHttpContentResolver HttpContentResolver { get; set; }
        IHttpResponseResolver HttpResponseResolver { get; set; }

        Task DeleteAsync<TContent>(string path, CancellationToken cancellationToken = default(CancellationToken));

        Task<TResult> GetAsync<TResult>(string path, CancellationToken cancellationToken = default(CancellationToken));

        Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken = default(CancellationToken));

        Task PatchAsync<TContent>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken));

        Task PostAsync<TContent>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken));

        Task<TResult> PostAsync<TContent, TResult>(string path, TContent content = default(TContent), CancellationToken cancellationToken = default(CancellationToken));

    }
}