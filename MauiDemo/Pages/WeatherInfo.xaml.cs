using MauiDemo.Models.ViewModels;

namespace MauiDemo.Pages;

public partial class WeatherInfo : ContentPage
{
	public WeatherInfo()
	{
        InitializeComponent();
        BindingContext = new WeatherInfoViewModel();
    }
}