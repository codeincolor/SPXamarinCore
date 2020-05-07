using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Constants;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Model;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using Xamarin.Forms;
using MenuItem = SocietyPass.Mobile.Services.Domain.MenuItem;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class MenuDetailViewModel : BaseViewModel, IMenuDetailVieweModel
    {
        private decimal _totalPrice;
        private int _quantity;
        private int _maxVal = 10;
        private int _minVal = 0;
        private Mobile.Services.Domain.MenuItem _selectedMenuItem;
        private Restaurant _selectedRestaurant;
        private IAsyncCommand _orderItemCommand;
        private IAsyncCommand _plusCommand;
        private IAsyncCommand _minusCommand;
        
        private readonly IRestaurantDataService _restaurantDataService;
        private readonly IMenuItemDataService _menuItemDataService;
        private readonly IOrderDataService _orderDataService;

        public decimal TotalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public Mobile.Services.Domain.MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        public Restaurant SelectedRestaurant
        {
            get => _selectedRestaurant;
            set => SetProperty(ref _selectedRestaurant, value);
        }

        public MenuDetailViewModel(INavigationService navigationService, IDialogService dialogService, IRestaurantDataService restaurantDataService, IMenuItemDataService menuItemDataService, ISettingsService settingsService)
            : base(navigationService, dialogService, settingsService)
        {
            _restaurantDataService = restaurantDataService;
            _menuItemDataService = menuItemDataService;
           // _orderDataService = orderDataService;
        }

        
        public IAsyncCommand MenuSelectedCommand => _orderItemCommand ?? (_orderItemCommand = new AsyncCommand<MenuItem>(OnItemOrdered));
        public IAsyncCommand PlusButtonCommand => _plusCommand ?? (_plusCommand = new AsyncCommand(OnPlusClicked));
        public IAsyncCommand MinusButtonCommand => _minusCommand ?? (_minusCommand = new AsyncCommand(OnMinusClicked));
        
        private async Task OnBuy()
        {

        }

        private async Task OnItemOrdered(MenuItem selectedMenuItem)
        {
            var orderItem = new OrderItem{Id=-1, MenuItem = SelectedMenuItem, MenuItemId = SelectedMenuItem.Id, Quantity = Quantity};
          
            _navigationService.OrderItems.Add(orderItem);
            await _dialogService.ShowDialog(SelectedMenuItem.Name + " added to your cart", "Success", "OK");
            await _navigationService.NavigateToAsync<RestaurantMenuViewModel>(SelectedRestaurant.Id);
        }

        private async Task OnPlusClicked()
        {
            Quantity+=1;
            TotalPrice = Quantity * SelectedMenuItem.Price;
        }
        private async Task OnMinusClicked()
        {
            if (Quantity != 0)
            {
                Quantity-=1;
                TotalPrice = Quantity * SelectedMenuItem.Price;

            }
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            if (objectToPass != null)
            {
                //get all details now
                if (objectToPass is MenuItemRestaurant menuItemRestaurant)
                {
                   SelectedMenuItem = await _menuItemDataService.GetMenuItemById(menuItemRestaurant.MenuItemId);
                    SelectedRestaurant = await _restaurantDataService.GetRestaurantById(menuItemRestaurant.RestaurantId);
                    TotalPrice = 0;
                }

            }
        }

    }
}
