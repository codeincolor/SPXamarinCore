using Newtonsoft.Json;
using SocietyPass.Mobile.Services.Contracts.Auth;

namespace SocietyPass.Mobile.Services.Auth
{
    public class OAuthError: IOAuthError
    {
        //TODO
        public string Description { get; set; }

        public string Error { get; set; }
    }
}