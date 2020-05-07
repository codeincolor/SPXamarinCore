using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Repositories.Extensions;

namespace SocietyPass.Mobile.Services.Repositories.ResponseResolvers
{
    public class SimpleJsonResponseResolver : IHttpResponseResolver
    {
        public async Task<TResult> ResolveHttpResponseAsync<TResult>(HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized, "", "");

                return default(TResult);
            }

            var responseAsString = await responseMessage.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<TResult>(responseAsString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            return json;
        }
    }
}