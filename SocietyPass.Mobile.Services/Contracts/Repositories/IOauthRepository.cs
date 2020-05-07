using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Auth;

namespace SocietyPass.Mobile.Services.Contracts.Repositories
{
    public interface IOAuthRepository
    {
        Task<IOAuthResult> AuthenticateUser(string username, string password);

    }
}