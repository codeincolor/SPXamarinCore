using System.Net;
using SocietyPass.Mobile.Services.Contracts.Auth;

namespace SocietyPass.Mobile.Services.Auth
{
    public class OAuthResult : IOAuthResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Status { get; set; }
        public IOAuthToken Token { get; set; }
    }
}
