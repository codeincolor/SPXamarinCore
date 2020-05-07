using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class RestaurantListViewModel : BaseViewModel, IRestaurantListViewModel
    {

        private ObservableRangeCollection<RestaurantListDto> _restaurants;
        private Restaurant _selectedRestaurant;
        private IAsyncCommand _restaurantSelectedCommand;
        private IRestaurantDataService _restaurantDataService;

        public ObservableRangeCollection<RestaurantListDto> Restaurants
        {
            get => _restaurants;
            set
            {
                _restaurants = value;
                OnPropertyChanged();
            }
        }

        public Restaurant SelectedRestaurant { get; set; }

        public IAsyncCommand RestaurantSelectedCommand => _restaurantSelectedCommand ??
                                                          (_restaurantSelectedCommand =
                                                              new AsyncCommand<Restaurant>(OnRestaurantSelectedCommand));

        public RestaurantListViewModel(INavigationService navigationService, IDialogService dialogService, IRestaurantDataService restaurantDataService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
            _restaurantDataService = restaurantDataService;
            Restaurants = new ObservableRangeCollection<RestaurantListDto>();
        }

        private async Task OnRestaurantSelectedCommand(Restaurant restaurant)
        {
            //TODO
            //
        }

        private async Task LoadRestaurants()
        {
            var restaurants = await _restaurantDataService.GetAllRestaurantsForList();
            Restaurants.ReplaceRange(restaurants);
        }

        public async override Task InitializeAsync(object objectToPass)
        {
           await LoadRestaurants();
        }
    }
}
