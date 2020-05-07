using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private ObservableRangeCollection<RestaurantListDto> _restaurantsTop;
        private ObservableRangeCollection<RestaurantListDto> _restaurants;
        private Restaurant _selectedRestaurant;
        private IAsyncCommand _restaurantSelectedCommand;
        private IAsyncCommand _orderViewCommand;
        private readonly IRestaurantDataService _restaurantDataService;

        public HomeViewModel(IRestaurantDataService restaurantDataService, INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
            _restaurantDataService = restaurantDataService;
            Restaurants = new ObservableRangeCollection<RestaurantListDto>();
            RestaurantsTop = new ObservableRangeCollection<RestaurantListDto>();
        }

        public ObservableRangeCollection<RestaurantListDto> Restaurants
        {
            get => _restaurants;
            set
            {
                _restaurants = value;
                OnPropertyChanged();
            }
        }

        public ObservableRangeCollection<RestaurantListDto> RestaurantsTop
        {
            get => _restaurantsTop;
            set
            {
                _restaurantsTop = value;
                OnPropertyChanged();
            }
        }

        public Restaurant SelectedRestaurant { get; set; }

        public IAsyncCommand RestaurantSelectedCommand =>
            _restaurantSelectedCommand ?? (_restaurantSelectedCommand = new AsyncCommand<RestaurantListDto>(OnRestaurantSelected));

        private async Task OnRestaurantSelected(RestaurantListDto restaurant)
        {
            await _navigationService.NavigateToAsync<RestaurantDetailViewModel>(restaurant);
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            var restaurants = await _restaurantDataService.GetAllRestaurantsForList();
            Restaurants.ReplaceRange(restaurants);

            RestaurantsTop.ReplaceRange(restaurants.Where(r=>r.Id > 4).AsEnumerable());

        }
    }

    public class RestaurantTemp : RestaurantListDto
    {
        public string BackgroundImage { get; set; }
    }
}