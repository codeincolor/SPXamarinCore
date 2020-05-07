using System.Linq;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class RestaurantDetailViewModel: BaseViewModel, IRestaurantDetailViewModel
    {
        private Restaurant _selectedRestaurant;
        private Utility.ObservableRangeCollection<Review> _reviews;
        private IAsyncCommand _menuSelectedCommand;
        private readonly IRestaurantDataService _restaurantDataService;
        private readonly IReviewDataService _reviewDataService;

        public Restaurant SelectedRestaurant
        {
            get => _selectedRestaurant;
            set => SetProperty(ref _selectedRestaurant, value);
        }

        public Utility.ObservableRangeCollection<Review> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged();
            }
        }

        public RestaurantDetailViewModel(INavigationService navigationService, IDialogService dialogService, IRestaurantDataService restaurantDataService, IReviewDataService reviewDataService, ISettingsService settingsService) 
            : base(navigationService, dialogService, settingsService)
        {
            _restaurantDataService = restaurantDataService;
            _reviewDataService = reviewDataService;
            _reviews = new Utility.ObservableRangeCollection<Review>();
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            if (objectToPass != null)
            {
                //get all details now
                if (objectToPass is RestaurantListDto restaurantListDto)
                {
                    SelectedRestaurant = await _restaurantDataService.GetRestaurantById(restaurantListDto.Id);
                    var reviews =  _reviewDataService.GetReviewByRestId(restaurantListDto.Id).Result.ToList();
                    Reviews.ReplaceRange(reviews);
                }
               
            }
        }

        public IAsyncCommand MenuSelectedCommand => _menuSelectedCommand ?? (_menuSelectedCommand = new AsyncCommand(OnMenuSelected));

        private async Task OnMenuSelected()
        {
            await _navigationService.NavigateToAsync<RestaurantMenuViewModel>(SelectedRestaurant.Id);
        }
    }
}
