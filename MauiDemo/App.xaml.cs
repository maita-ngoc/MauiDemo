using MauiDemo.Pages;

namespace MauiDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new WeatherInfo();
           // MainPage = new AppShell();
        }
    }
}
