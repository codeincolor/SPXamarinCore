using Autofac;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Messaging;
using SocietyPass.Mobile.Core.Services;
using SocietyPass.Mobile.Core.ViewModels;
using SocietyPass.Mobile.Core.Views;
using SocietyPass.Mobile.Services.Contracts.API;
using SocietyPass.Mobile.Services.Contracts.Messaging;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Repositories;
using SocietyPass.Mobile.Services.Repositories.Client;
using SocietyPass.Mobile.Services.Services;

namespace SocietyPass.Mobile.Core
{
    public class AppModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Api
            builder.RegisterType<WebApiClient>().As<IWebApiClient>().SingleInstance();

            //Messaging
            builder.RegisterType<Messenger>().As<IMessenger>().SingleInstance();

            //Repository
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRespository>().SingleInstance();
            builder.RegisterType<OAuthRepository>().As<IOAuthRepository>().SingleInstance();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>().SingleInstance();
            builder.RegisterType<RestaurantMenuRepository>().As<IRestaurantMenuRepository>().SingleInstance();
            builder.RegisterType<MenuItemRepository>().As<IMenuItemRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();

            // Services
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();

            // Data services
            builder.RegisterType<OAuthService>().As<IOAuthService>().SingleInstance();
            builder.RegisterType<RestaurantDataService>().As<IRestaurantDataService>().SingleInstance();
            builder.RegisterType<ReviewDataService>().As<IReviewDataService>().SingleInstance();
            builder.RegisterType<RestaurantMenuDataService>().As<IRestaurantMenuDataService>().SingleInstance();
            builder.RegisterType<MenuItemDataService>().As<IMenuItemDataService>().SingleInstance();
            builder.RegisterType<OrderDataService>().As<IOrderDataService>().SingleInstance();

            // ViewModels
            builder.RegisterType<RestaurantListViewModel>().As<IRestaurantListViewModel>();
            builder.RegisterType<RestaurantDetailViewModel>().As<IRestaurantDetailViewModel>();
            //builder.RegisterType<ReviewListViewModel>().As<IReviewListViewModel>();
            builder.RegisterType<ReviewDetailViewModel>().As<IReviewDetailViewModel>();

            builder.RegisterType<DiscoverViewModel>();//.As<IDiscoverViewModel>();
            builder.RegisterType<FavoritesViewModel>();//.As<IFavoritesViewModel>();
            builder.RegisterType<HomeViewModel>();//.As<IHomeViewModel>();
            builder.RegisterType<LoginViewModel>();//.As<ILoginViewModel>();
            builder.RegisterType<ProfileViewModel>();//.As<IProfileViewModel>();
            builder.RegisterType<RestaurantSearchViewModel>();//.As<IRestaurantSearchViewModel>();
            builder.RegisterType<ReviewListViewModel>();
            builder.RegisterType<ReviewDetailViewModel>();
            builder.RegisterType<RestaurantDetailViewModel>();//.As<IRestaurantSearchViewModel>();
            builder.RegisterType<ExtendedSplashViewModel>();//.As<IExtendedSplashViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
            builder.RegisterType<MainViewModel>();//.As<IMenuViewModel>();
            builder.RegisterType<RegisterViewModel>();//.As<IMenuViewModel>();
            builder.RegisterType<RestaurantMenuViewModel>().As<IRestuarantMenuViewModel>();
            builder.RegisterType<RestaurantMenuViewModel>();
            builder.RegisterType<MenuDetailViewModel>().As<IMenuDetailVieweModel>();
            builder.RegisterType<MenuDetailViewModel>();
            builder.RegisterType<OrderViewModel>().As<IOrderViewModel>();
            builder.RegisterType<OrderViewModel>();

            // views
            builder.RegisterType<RestaurantListView>();
            builder.RegisterType<RestaurantDetailView>();
            builder.RegisterType<RestaurantMenuView>();
            builder.RegisterType<ReviewListView>();
            builder.RegisterType<ReviewDetailView>();
            builder.RegisterType<HomeView>();
            builder.RegisterType<FavoritesView>();
            builder.RegisterType<DiscoverView>();
            builder.RegisterType<LoginView>();
            builder.RegisterType<RestaurantSearchView>();
            builder.RegisterType<ProfileView>();
            builder.RegisterType<MenuView>();
            builder.RegisterType<MenuDetailView>();
            builder.RegisterType<OrderView>();
        }
    }
}
