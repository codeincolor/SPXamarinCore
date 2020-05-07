using SocietyPass.Mobile.Core.Constants;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using System.Windows.Input;
using SocietyPass.Mobile.Services.Domain;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SocietyPass.Mobile.Services.Contracts.Services;
using MenuItem = SocietyPass.Mobile.Services.Domain.MenuItem;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class OrderViewModel : BaseViewModel, IOrderViewModel
    {
        private ObservableCollection<OrderItem> _orderItems;
        private readonly ISettingsService _settingsService;
        private readonly IOrderDataService _orderDataService;

        private decimal _orderTotal;
        private decimal _taxes;
        private decimal _shipping;
        private decimal _grandTotal;

        public OrderViewModel(INavigationService navigationService, IDialogService dialogService, IOrderDataService orderDataService, ISettingsService settingsService)
            : base(navigationService, dialogService, settingsService)
        {
          
            _settingsService = settingsService;
            _orderDataService = orderDataService;
           if( _orderItems == null)_orderItems = new ObservableCollection<OrderItem>();
           
        }

        public ICommand CheckOutCommand => new Command(OnCheckOut);

        public ObservableCollection<OrderItem> OrderItems
        {
            get => _navigationService.OrderItems;
            set
            {
                _orderItems = value;
                RecalculateOrder();
                OnPropertyChanged();
            }
        }

        public decimal GrandTotal
        {
            get => _grandTotal;
            set
            {
                _grandTotal = value;
                OnPropertyChanged();
            }
        }

        public decimal Shipping
        {
            get => _shipping;
            set
            {
                _shipping = value;
                OnPropertyChanged();
            }
        }

        public decimal Taxes
        {
            get => _taxes;
            set
            {
                _taxes = value;
                OnPropertyChanged();
            }
        }

        public int CartCount
        {
            get => _navigationService.CartCount;
        }

        public void InitializeMessenger()
        {
            MessagingCenter.Subscribe<MenuDetailViewModel, OrderItem>(this, MessagingConstants.AddMenuItemToOrder,async (MenuDetailViewModel menuDetailViewModel, OrderItem orderItem) =>
            {
                OrderItems.Add(orderItem);
                await _orderDataService.AddOrderItem(orderItem, _settingsService.UserIdSetting);
            });

            //MessagingCenter.Subscribe<HomeViewModel, OrderItem>(this, MessagingConstants.AddMenuItemToOrder,
            //    (homeViewModel, orderItem) => OnAddMenuItemToBasketReceived(orderItem));
            //MessagingCenter.Subscribe<CheckoutViewModel>(this, MessagingConstants.OrderPlaced, model => OnOrderPlaced());
        }

        //private async void OnAddMenuItemToBasketReceived(OrderItem orderItem)
        //{
        //   // var shoppingCartItem = new ShoppingCartItem() { Pie = pie, PieId = pie.PieId, Quantity = 1 };
        //    //var orderItem = new OrderItem
        //    //{
        //    //    Id = 0, Quantity = menuDetailView.Quantity, orderId = 0,
        //    //    MenuItemId = menuDetailView.SelectedMenuItem.Id, SpecialInstructions = ""
        //    //};
        //    OrderItems.Add(orderItem);
        //    await _orderDataService.AddOrderItem(orderItem, _settingsService.UserIdSetting);

        //   // ShoppingCartItems.Add(shoppingCartItem);

        //    RecalculateOrder();
        //}
        private void OnCheckOut()
        {
            _navigationService.NavigateToAsync<CheckoutViewModel>();
        }
        private void OnOrderPlaced()
        {
            OrderItems.Clear();
        }
        private void RecalculateOrder()
        {
            _orderTotal = CalculateOrderTotal();
            Taxes = _orderTotal * (decimal)0.2;
            Shipping = _orderTotal * (decimal)0.1;
            GrandTotal = _orderTotal + _shipping + _taxes;
        }

        private decimal CalculateOrderTotal()
        {
            decimal total = 0;

            foreach (var orderItem in OrderItems)
            {
                total += orderItem.Quantity * orderItem.MenuItem.Price;
            }

            return total;
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            if (objectToPass != null)
            {
                //get all details now
                if (objectToPass is Order restaurantListDto)
                {
                    //SelectedRestaurant = await _restaurantDataService.GetRestaurantById(restaurantListDto.Id);
                    //var reviews = _reviewDataService.GetReviewByRestId(restaurantListDto.Id).Result.ToList();
                    //Reviews.ReplaceRange(reviews);
                }

            }
        }

    }
}