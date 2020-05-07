using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class LoginViewModel: BaseViewModel, ILoginViewModel
    {
        private IAsyncCommand _loginCommand;
        private IAsyncCommand _registerCommand;
        private readonly IOAuthService _oAuthService;
        private string _userName;
        private string _password;

        public LoginViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService, IOAuthService oAuthService) : base(navigationService, dialogService, settingsService)
        {
            _oAuthService = oAuthService;
            UserName = "joeconaty";
            Password = "testpass?";
        }

        //TODO: change these into Validate version so we can block attempts to log in without username and password
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IAsyncCommand LoginCommand => _loginCommand ??
                                                          (_loginCommand =
                                                              new AsyncCommand(OnLoginCommand));

        private async Task OnLoginCommand()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                //var auth = await _oAuthService.Login(UserName, Password);
                //_settingsService.AuthAccessToken = auth.Token.Token;
                await _navigationService.NavigateToAsync<MainViewModel>();
            }
            else
            {
                //show dialog using dialogservice
            }
        }

        public IAsyncCommand RegisterCommand =>
            _registerCommand ?? (_registerCommand = new AsyncCommand(OnRegisterCommand));

        private Task OnRegisterCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}