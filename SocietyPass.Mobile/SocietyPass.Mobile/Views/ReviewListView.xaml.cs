using SocietyPass.Mobile.Core.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocietyPass.Mobile.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReviewListView : ContentPage
	{
		public ReviewListView()
		{
			InitializeComponent ();

            //this.BindingContext = reviewListViewModel;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var vm = (IReviewListViewModel)BindingContext;

        //    //TODO: we are changing this, moving to NavigationService
        //    //vm.Init();
        //}
    }
}