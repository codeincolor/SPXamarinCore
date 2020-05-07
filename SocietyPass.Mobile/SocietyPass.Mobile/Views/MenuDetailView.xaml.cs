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
	public partial class MenuDetailView : ContentPage
	{
		public MenuDetailView ()
		{
			InitializeComponent ();
		}

	    private  void PlusButton_OnClicked(object sender, EventArgs e)
	    {
	        //if (MaxValue > Value)
	        //    try
	        //    {
	        //        await StepLabel.ScaleTo(1.3, 100);
	        //        Value += Step;
	        //        await StepLabel.ScaleTo(1, 100);
	        //    }
	        //    catch (Exception)
	        //    {
	        //        // ignored
	        //    }
	    }

	    private  void MinusButton_OnClicked(object sender, EventArgs e)
	    {
	        //if (MinValue < Value)
	        //    try
	        //    {
	        //        await StepLabel.ScaleTo(1.3, 100);
	        //        Value -= Step;
	        //        await StepLabel.ScaleTo(1, 100);
	        //    }
	        //    catch (Exception)
	        //    {
	        //        // ignored
	        //    }
	    }
    }
}