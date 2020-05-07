using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.ViewModels;
using SocietyPass.Mobile.Core.Views;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using Xamarin.Forms;

namespace SocietyPass.Mobile.Core.Services
{
    public class NavigationService: INavigationService
    {
        //TODO: Move Cart/Order Info to its own service.
        private Order _order;
        private ObservableCollection<OrderItem> _orderItems;

        private readonly IOAuthService _authService;
        private readonly ISettingsService _settingsService;
        private readonly Dictionary<Type, Type> _mappings;

        public int CartCount { get; set; }

        public ObservableCollection<OrderItem> OrderItems
        {
            get => _orderItems;
            set
            {
                _orderItems = value; 
                if(Order == null)Order = new Order{Id = 0, OrderItems = OrderItems, RestaurantId = 0, OrderPlaced = false, OrderId = Guid.NewGuid().ToString(), UserId = 1};
            }
        }
        public Order Order { get; private set; }


        protected Application CurrentApplication => Application.Current;

        public NavigationService(IOAuthService authService, ISettingsService settingsService)
        {
            this._authService = authService;
            _settingsService = settingsService;
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
            OrderItems = new ObservableCollection<OrderItem>();
        }

        public async Task InitializeAsync()
        {
            if (await _authService.IsUserAuthenticated())//TODO
            //if(!string.IsNullOrEmpty(_settingsService.AuthAccessToken ))//we also need to validate that the token is still valid, not happening right now
            {
                await NavigateToAsync<MainViewModel>();
            }
            else
            {
                await NavigateToAsync<LoginViewModel>();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public Task NavigateToAsync(Type viewModelType) => InternalNavigateToAsync(viewModelType, null);

        public Task NavigateToAsync(Type viewModelType, object parameter) => InternalNavigateToAsync(viewModelType, parameter);

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreateAndBindPage(viewModelType, parameter);

            if (page is MainView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (page is LoginView)
            {
                CurrentApplication.MainPage = new MainNavigationView(page);
            }
            else if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;

                if (mainPage.Detail is MainNavigationView navigationPage)
                {
                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        await navigationPage.PushAsync(page);
                    }
                }
                else
                {
                    navigationPage = new MainNavigationView(page);
                    mainPage.Detail = navigationPage;
                }

                mainPage.IsPresented = false;
            }
            else
            {
                if (CurrentApplication.MainPage is MainNavigationView navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new MainNavigationView(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = AppContainer.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;

            return page;
        }

        void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(DiscoverViewModel), typeof(DiscoverView));
            _mappings.Add(typeof(ExtendedSplashViewModel), typeof(ExtendedSplashView));
            _mappings.Add(typeof(ReviewListViewModel), typeof(ReviewListView));
            _mappings.Add(typeof(ReviewDetailViewModel), typeof(ReviewDetailView));
            _mappings.Add(typeof(HomeViewModel), typeof(HomeView));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(ProfileViewModel), typeof(ProfileView));
            _mappings.Add(typeof(RestaurantDetailViewModel), typeof(RestaurantDetailView));
            _mappings.Add(typeof(RestaurantListViewModel), typeof(RestaurantListView));
            _mappings.Add(typeof(RestaurantSearchViewModel), typeof(RestaurantSearchView));
            _mappings.Add(typeof(MenuViewModel), typeof(MenuView));
            _mappings.Add(typeof(RegisterViewModel), typeof(RegisterView));
            _mappings.Add(typeof(RestaurantMenuViewModel), typeof(RestaurantMenuView));
            _mappings.Add(typeof(MenuDetailViewModel), typeof(MenuDetailView));
            _mappings.Add(typeof(OrderViewModel), typeof(OrderView));
        }
    }
}
