using MauiDemo.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiDemo.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;
        public WeatherApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constant.Api_Base_URL);
        }

        public async Task<WeatherApiResponse> GetWeatherInformation (string latitude, string longitude)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new WeatherApiResponse { Error = "No internet connection" }; // Return a meaningful error

            try
            {
                // Make the API request
                var response = await _httpClient.GetFromJsonAsync<WeatherApiResponse>(
                    $"current?access_key={Constant.APIKey}&query={latitude},{longitude}");

                return response ?? new WeatherApiResponse { Error = "No data received" };
            }
            catch (Exception ex)
            {
                // Handle possible exceptions like network errors or deserialization issues
                return new WeatherApiResponse { Error = ex.Message };
            }
        }
    }
}
