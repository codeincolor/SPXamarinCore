using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class ExtendedSplashViewModel: BaseViewModel, IExtendedSplashViewModel
    {
        public ExtendedSplashViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            IsLoading = true;
            //location, initial data fetching
            await _navigationService.InitializeAsync();

            IsLoading = false;
        }
    }
}
