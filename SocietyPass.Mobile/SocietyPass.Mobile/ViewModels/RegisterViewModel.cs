using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class RegisterViewModel: BaseViewModel, IRegisterViewModel
    {

        private IAsyncCommand _loginCommand;
        private IAsyncCommand _registerCommand;
        private readonly IOAuthService _oAuthService;
        private string _userName;
        private string _password;

        public RegisterViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService, IOAuthService oAuthService) : base(navigationService, dialogService, settingsService)
        {
            _oAuthService = oAuthService;
        }

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

        private Task OnLoginCommand()
        {
            return Task.CompletedTask;
        }

        public IAsyncCommand RegisterCommand =>
            _registerCommand ?? (_registerCommand = new AsyncCommand(OnRegisterCommand));

        private Task OnRegisterCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}
