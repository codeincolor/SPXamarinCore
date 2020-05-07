using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using SocietyPass.Mobile.Services.Contracts.API;

namespace SocietyPass.Mobile.Services.Repositories.ContentResolvers
{
    public class SimpleJsonContentResolver : IHttpContentResolver
    {
        public HttpContent ResolveHttpContent<TContent>(TContent content)
        {
            var serializedContent = JsonConvert.SerializeObject(content);

            return new StringContent(serializedContent, Encoding.UTF8, "application/json");
        }
    }
}
