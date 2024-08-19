using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiDemo.Models.ApiModels
{
    public class WeatherApiResponse
    {
        [JsonPropertyName ("request")]
        public WeatherApiResponseRequest Request { get; set; }
        [JsonPropertyName("location")]
        public WeatherApiResponseLocation Location { get; set; }
        [JsonPropertyName("current")]
        public WeatherApiResponseCurrent Current { get; set; }
        public string Error { get; internal set; }
    }
    public class WeatherApiResponseRequest
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }

    public class WeatherApiResponseLocation
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Timezone_id { get; set; }
        public string Localtime { get; set; }
        public int Localtime_epoch { get; set; }
        public string Utc_offset { get; set; }
    }

    public class WeatherApiResponseCurrent
    {
        public string Observation_time { get; set; }
        public int Temperature { get; set; }
        public int Weather_code { get; set; }
        public string[] Weather_icons { get; set; }
        public string[] Weather_descriptions { get; set; }
        //public int Wind_speed { get; set; }
        //public int Wind_degree { get; set; }
        //public string wind_dir { get; set; }
        //public int pressure { get; set; }
        //public int precip { get; set; }
        public int Humidity { get; set; }
        public int Cloudcover { get; set; }
        //public int feelslike { get; set; }
        //public int uv_index { get; set; }
        //public int visibility { get; set; }
        public string Is_day { get; set; }
    }

}
