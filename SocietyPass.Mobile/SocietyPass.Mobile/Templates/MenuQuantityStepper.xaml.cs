﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocietyPass.Mobile.Core.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuQuantityStepper : ContentView
	{
	    public static readonly BindableProperty MaxValueProperty =
	        BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(MenuQuantityStepper), int.MaxValue);

	    public static readonly BindableProperty MinValueProperty =
	        BindableProperty.Create(nameof(MinValue), typeof(int), typeof(MenuQuantityStepper), int.MinValue);

	    public static readonly BindableProperty ValueProperty =
	        BindableProperty.Create(nameof(Value), typeof(double), typeof(MenuQuantityStepper), 0D, BindingMode.TwoWay, null,
	            ValuePropertyChanged);

	    public static readonly BindableProperty StepProperty =
	        BindableProperty.Create(nameof(Step), typeof(double), typeof(MenuQuantityStepper), 1D);
        public MenuQuantityStepper ()
		{
			InitializeComponent ();
		    Value = 123;
		    MinValue = 0;
            Margin = new Thickness(15);
		    StepLabel.Text = Value.ToString();
        }

	    public int MaxValue
	    {
	        get => (int)GetValue(MaxValueProperty);
	        set => SetValue(MaxValueProperty, value);
	    }

	    public int MinValue
	    {
	        get => (int)GetValue(MinValueProperty);
	        set => SetValue(MinValueProperty, value);
	    }

	    public double Value
	    {
	        get => (double)GetValue(ValueProperty);
	        set => SetValue(ValueProperty, value);
	    }

	    public double Step
	    {
	        get => (double)GetValue(StepProperty);
	        set => SetValue(StepProperty, value);
	    }

	    private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	    {
	        if (bindable is MenuQuantityStepper stepperView)
	            stepperView.StepLabel.Text = newValue.ToString();
	    }


	    private async void PlusButton_OnClicked(object sender, EventArgs e)
	    {
	        if (MaxValue > Value)
	            try
	            {
	                await StepLabel.ScaleTo(1.3, 100);
	                Value += Step;
	                await StepLabel.ScaleTo(1, 100);
	            }
	            catch (Exception)
	            {
	                // ignored
	            }
	    }

	    private async void MinusButton_OnClicked(object sender, EventArgs e)
	    {
	        if (MinValue < Value)
	            try
	            {
	                await StepLabel.ScaleTo(1.3, 100);
	                Value -= Step;
	                await StepLabel.ScaleTo(1, 100);
	            }
	            catch (Exception)
	            {
	                // ignored
	            }
	    }
    }
}