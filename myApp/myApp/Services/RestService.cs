using myApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Services
{
    public class RestService
    {
        HttpClient client;

        public  RestService()
        {
            client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(String query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await client.GetAsync(query);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return weatherData;
        }
    }
}
