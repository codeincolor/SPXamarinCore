using System;
using System.Threading.Tasks;
using SocietyPass.Mobile.Services.Contracts.Auth;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Contracts.Services;

namespace SocietyPass.Mobile.Services.Services
{
    public class OAuthService : IOAuthService
    {
        protected readonly IOAuthRepository _oAuthRepository;


        public OAuthService(IOAuthRepository oAuthRepository)
        {
            _oAuthRepository = oAuthRepository;
        }

        public Task<IOAuthToken> GetToken()
        {
            throw new NotImplementedException();
        }

        public Task<IOAuthResult> Login(string username, string password)
        {
            var result = _oAuthRepository.AuthenticateUser(username, password);
            return result;
        }

        public Task<bool> IsUserAuthenticated()
        {
            //return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}