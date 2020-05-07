using System.Net;

namespace SocietyPass.Mobile.Services.Contracts.Auth
{
    public interface IOAuthResult
    {
        HttpStatusCode StatusCode { get; set; }
        string Status { get; set; }
        IOAuthToken Token { get; set; }
    }
}