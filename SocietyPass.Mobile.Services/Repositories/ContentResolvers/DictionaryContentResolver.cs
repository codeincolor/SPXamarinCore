using System.Collections.Generic;
using System.Net.Http;

namespace SocietyPass.Mobile.Services.Repositories.ContentResolvers
{
    public class DictionaryContentResolver
    {
        public HttpContent ResolveHttpContent(Dictionary<string, string> content)
        {
            return new FormUrlEncodedContent(content);
        }
    }
}