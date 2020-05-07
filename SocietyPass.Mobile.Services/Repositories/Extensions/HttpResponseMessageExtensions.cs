using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Repositories.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            response.Content?.Dispose();

            throw new HttpResponseException(response.StatusCode, response.ReasonPhrase, content);
        }
    }
}