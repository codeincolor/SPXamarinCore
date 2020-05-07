using SocietyPass.Mobile.Core.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Views;
using SocietyPass.Mobile.Core.Model;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class RestaurantMenuViewModel : BaseViewModel, IRestuarantMenuViewModel
    {

        private Restaurant _selectedRestaurant;
        private MenuItem _selectedMenuItem;
        private Utility.ObservableRangeCollection<MenuItem> _menuItems;
        private IAsyncCommand _menuSelectedCommand;
        private readonly IRestaurantDataService _restaurantDataService;
        private readonly IRestaurantMenuDataService _menuDataService;


        public Restaurant SelectedRestaurant
        {
            get => _selectedRestaurant;
            set => SetProperty(ref _selectedRestaurant, value);
        }
        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        public Utility.ObservableRangeCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }
        public RestaurantMenuViewModel(INavigationService navigationService, IDialogService dialogService, IRestaurantDataService restaurantDataService, IRestaurantMenuDataService menuDataService, ISettingsService settingsService)
            : base(navigationService, dialogService, settingsService)
        {
            _restaurantDataService = restaurantDataService;
            _menuDataService = menuDataService;
            _menuItems = new Utility.ObservableRangeCollection<MenuItem>();
        }

        public IAsyncCommand MenuSelectedCommand => _menuSelectedCommand ?? (_menuSelectedCommand = new AsyncCommand<MenuItem>(OnMenuSelected));

        private async Task OnMenuSelected(MenuItem menu)
        {
            
            await _navigationService.NavigateToAsync<MenuDetailViewModel>(new MenuItemRestaurant{MenuItemId = menu.Id, RestaurantId = SelectedRestaurant.Id});
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            if (objectToPass != null)
            {
                //get all details now
                if (objectToPass is int restaurantId)
                {
                    SelectedRestaurant = await _restaurantDataService.GetRestaurantById(restaurantId);
                    var menu = await _menuDataService.GetRestaurantMenusById(restaurantId);
                    Menu m = menu.FirstOrDefault();
                    MenuItems.ReplaceRange(m.MenuItems);
                }

            }
        }

    }
}
