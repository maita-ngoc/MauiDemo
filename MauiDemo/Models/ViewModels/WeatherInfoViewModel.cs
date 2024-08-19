using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDemo.Models.ViewModels
{
    public partial class WeatherInfoViewModel : ObservableObject
    {
        private readonly WeatherApiService _weatherApiService;
        public WeatherInfoViewModel()
        {
            _weatherApiService = new WeatherApiService();
            InitializeAsync();
        }
        [ObservableProperty]
        public string latitude;

        [ObservableProperty]
        public string longitude;

        [ObservableProperty]
        public string weatherIcon;

        [ObservableProperty]
        public string temperature;

        [ObservableProperty]
        public string weatherDescription;

        [ObservableProperty]
        public string location;

        [ObservableProperty]
        public string humidity;

        [ObservableProperty]
        public string cloudCoverLevel;

        [ObservableProperty]
        public string isDay;

        private bool _isCurrentLocation = true;
        private async Task InitializeAsync()
        {
            _isCurrentLocation = true; // Set to true to use the current location on startup
            await FetchWeatherInformation(); // Fetch weather for the current location
        }

        [RelayCommand]
        public async Task FetchWeatherInformation()
        {
            if (_isCurrentLocation)
            {
                // Get the current location's latitude and longitude
                var (latitude, longitude) = await GetCurrentLocationAsync();
                Latitude = latitude.ToString();
                Longitude = longitude.ToString();
            }
            try
            {
                var weatherApiResponse = await _weatherApiService.GetWeatherInformation(Latitude, Longitude);
                if (weatherApiResponse != null)
                {
                    WeatherIcon = weatherApiResponse.Current.Weather_icons[0];
                    Temperature = $"{weatherApiResponse.Current.Temperature}°C";
                    Location = $"{weatherApiResponse.Location.Name}, {weatherApiResponse.Location.Country}";
                    WeatherDescription = weatherApiResponse.Current.Weather_descriptions[0];
                    Humidity = $"{weatherApiResponse.Current.Humidity}";
                    CloudCoverLevel = $"{weatherApiResponse.Current.Cloudcover}%";
                    IsDay = $"{weatherApiResponse.Current.Is_day}";
                }
                _isCurrentLocation = false;
            }catch (Exception ex) { throw ex; }
            
        }

        private async Task<(double Latitude, double Longitude)> GetCurrentLocationAsync()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }

            if (location != null)
            {
                return (location.Latitude, location.Longitude);
            }
            throw new Exception("Unable to get current location.");
        }
    }

}
