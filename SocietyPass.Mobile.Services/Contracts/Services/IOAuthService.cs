using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Auth;

namespace SocietyPass.Mobile.Services.Contracts.Services
{
    public interface IOAuthService
    {
        Task<IOAuthToken> GetToken();
        Task<IOAuthResult> Login(string username, string password);
        Task<bool> IsUserAuthenticated();
    }
}