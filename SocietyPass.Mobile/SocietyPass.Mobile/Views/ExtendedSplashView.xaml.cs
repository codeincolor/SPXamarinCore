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
	public partial class ExtendedSplashView : ContentPage
	{
		public ExtendedSplashView ()
		{
			InitializeComponent ();

		   // BindingContext = extendedSplashViewModel;
		}


	}
}