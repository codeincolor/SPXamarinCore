using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Utility;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class BaseViewModel: ObservableObject
    {
        protected readonly INavigationService _navigationService;
        protected readonly IDialogService _dialogService;
        protected readonly ISettingsService _settingsService;

        private IAsyncCommand _orderViewCommand;
        private bool _isLoading;

        public BaseViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _settingsService = settingsService;
        }

        public IAsyncCommand OrderViewRequestedCommand =>
            _orderViewCommand ?? (_orderViewCommand = new AsyncCommand(OnOrderViewRequested));

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public virtual Task InitializeAsync(object objectToPass)
        {
            return Task.FromResult(false);
        }
        private async Task OnOrderViewRequested()
        {
            await _navigationService.NavigateToAsync<OrderViewModel>();
        }
    }
}
