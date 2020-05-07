using Newtonsoft.Json;
using SocietyPass.Mobile.Services.Contracts.Auth;

namespace SocietyPass.Mobile.Services.Auth
{
    public class OAuthToken: IOAuthToken
    {
        //[JsonProperty("expires")]
        //public int ExpiresIn { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
