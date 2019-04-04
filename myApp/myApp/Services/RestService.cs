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
                //Get Request
                var response = await client.GetAsync(query);
                //If receive back HTTP Status code between 200-299, read in the data received from the get Request
                if(response.IsSuccessStatusCode)
                {
                    //Serialize the HTTP Content to a string called content
                    var content = await response.Content.ReadAsStringAsync();
                    //JSON convert and deserialize content as WeatherData Object
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            //Prints out Error + exception if http request fails
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return weatherData;
        }
    }
}
