using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class MainViewModel: BaseViewModel, IMainViewModel
    {
        private IMenuViewModel _menuViewModel;
         
        public MainViewModel(IMenuViewModel menuViewModel, INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
            _menuViewModel = menuViewModel;
        }

        public IMenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set => SetProperty(ref _menuViewModel, value);
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            await _navigationService.NavigateToAsync<HomeViewModel>();
        }
    }
}
