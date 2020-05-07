using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocietyPass.Mobile.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantListView : ContentPage
    {
        public RestaurantListView(IRestaurantListViewModel restaurantListViewModel)
        {
            InitializeComponent();

            this.BindingContext = restaurantListViewModel;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var vm = (IRestaurantListViewModel)BindingContext;

        //    //TODO: we are changing this, moving to NavigationService
        //    //vm.Init();
        //}
    }
}