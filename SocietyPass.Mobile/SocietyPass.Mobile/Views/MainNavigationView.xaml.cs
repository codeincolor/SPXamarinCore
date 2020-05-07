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
	public partial class MainNavigationView : NavigationPage
	{
		public MainNavigationView ()
		{
			InitializeComponent ();
		}

	    public MainNavigationView(Page page) : base(page)
	    {
            InitializeComponent();
	    }
	}
}