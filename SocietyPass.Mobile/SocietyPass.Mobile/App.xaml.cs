using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.ViewModels;
using SocietyPass.Mobile.Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SocietyPass.Mobile.Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            //var extendedSplashScreen = new ExtendedSplashView(AppContainer.Resolve<IExtendedSplashViewModel>());
            //MainPage = extendedSplashScreen;
            var navigationService = AppContainer.Resolve<INavigationService>();
            navigationService.NavigateToAsync<ExtendedSplashViewModel>();

            var orderViewModel = AppContainer.Resolve<OrderViewModel>();
            orderViewModel.InitializeMessenger();


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
