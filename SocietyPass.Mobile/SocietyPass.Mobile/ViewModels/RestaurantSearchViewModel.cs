using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class RestaurantSearchViewModel : BaseViewModel, IRestaurantSearchViewModel
    {
        private ObservableRangeCollection<RestaurantListDto> _restaurants;
        private Restaurant _selectedRestaurant;
        private IAsyncCommand _restaurantSelectedCommand;
        private readonly IRestaurantDataService _restaurantDataService;

        public RestaurantSearchViewModel(IRestaurantDataService restaurantDataService, 
            INavigationService navigationService, IDialogService dialogService, 
            ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
            _restaurantDataService = restaurantDataService;
            Restaurants = new ObservableRangeCollection<RestaurantListDto>();
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

        public int RestaurantCount
        {
            get => Restaurants.Count;
        }

        public Restaurant SelectedRestaurant { get; set; }

        public IAsyncCommand RestaurantSelectedCommand => _restaurantSelectedCommand ?? (_restaurantSelectedCommand = new AsyncCommand<RestaurantListDto>(OnRestaurantSelected));

        private async Task OnRestaurantSelected(RestaurantListDto restaurant)
        {
            await _navigationService.NavigateToAsync<RestaurantDetailViewModel>(restaurant);
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            var restaurants = await _restaurantDataService.GetAllRestaurantsForList();
            Restaurants.ReplaceRange(restaurants);
        }

    }
}
