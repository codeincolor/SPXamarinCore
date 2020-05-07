using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Model;
using SocietyPass.Mobile.Core.Utility;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class MenuViewModel: BaseViewModel, IMenuViewModel
    {
        private ObservableRangeCollection<NavigationMenuItem> _menuItems;
        private string _welcomeText;
        private IAsyncCommand _menuItemSelectedCommand;

        public MenuViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
            MenuItems = new ObservableRangeCollection<NavigationMenuItem>();
            LoadMenuItems();
            WelcomeText = "Welcome to Society Pass";
        }

        public ObservableRangeCollection<NavigationMenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public string WelcomeText
        {
            get => _welcomeText;
            set => SetProperty(ref _welcomeText, value);
        }

        public IAsyncCommand MenuItemSelectedCommand => _menuItemSelectedCommand ??
                                                          (_menuItemSelectedCommand =
                                                              new AsyncCommand<NavigationMenuItem>(OnSelectMenuItem));

        private async Task OnSelectMenuItem(NavigationMenuItem navigationMenuItem)
        {
            await _navigationService.NavigateToAsync(navigationMenuItem.ViewModelType, navigationMenuItem);
        }

        void LoadMenuItems()
        {
            MenuItems.Add(new NavigationMenuItem
            {
                Title = "Home",
                MenuItemType = NavigationMenuItemType.Home,
                ViewModelType = typeof(MainViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new NavigationMenuItem
            {
                Title = "Discover",
                MenuItemType = NavigationMenuItemType.Discover,
                ViewModelType = typeof(DiscoverViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new NavigationMenuItem
            {
                Title = "Search restaurant",
                MenuItemType = NavigationMenuItemType.Restaurants,
                ViewModelType = typeof(RestaurantSearchViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new NavigationMenuItem
            {
                Title = "Favorites",
                MenuItemType = NavigationMenuItemType.Favorites,
                ViewModelType = typeof(ReviewListViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new NavigationMenuItem
            {
                Title = "Profile",
                MenuItemType = NavigationMenuItemType.Profile,
                ViewModelType = typeof(ProfileViewModel),
                IsEnabled = true
            });
        }
    }
}
