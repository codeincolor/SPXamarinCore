using SocietyPass.Mobile.Core.Contracts.Services;
using System.Windows.Input;
using SocietyPass.Mobile.Services.Domain;
using Xamarin.Forms;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using System.Threading.Tasks;
using System;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class CheckoutViewModel : BaseViewModel, ICheckoutViewModel
    {
        private readonly IOrderDataService _orderDataService;
        private readonly ISettingsService _settingsService;
        private readonly IDialogService _dialogService;

        private Order _order;

        public CheckoutViewModel(INavigationService navigationService, IDialogService dialogService, IConnectionService connectionService,
            IOrderDataService orderDataService, ISettingsService settingsService)
            : base( navigationService, dialogService, settingsService)
        {
            _orderDataService = orderDataService;
            _settingsService = settingsService;
            _dialogService = dialogService;
        }

        public ICommand PlaceOrderCommand => new Command(OnPlaceOrder);

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object data)
        {
            Order = new Order { OrderId = Guid.NewGuid().ToString(), UserId = 0, RestaurantId = 0};

            return base.InitializeAsync(data);
        }

        private async void OnPlaceOrder()
        {
            await _orderDataService.PlaceOrder(Order);
            MessagingCenter.Send(this, "OrderPlaced");
            await _dialogService.ShowDialog("Order placed successfully", "Success", "OK");
           // await _navigationService.PopToRootAsync();
        }
    }
}