using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace facade;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainPageViewModel();
	}
}


