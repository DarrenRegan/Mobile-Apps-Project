using myApp.Models;
using myApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace myApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        RestService _restService;

        public WeatherPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                //Requests http://api.openweathermap.org/data/2.5/weather + API Key to get data
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        private string GenerateRequestUri(string openWeatherMapEndpoint)
        {
            //This will request the data using the full directory
            //The request should look like this 
            //"http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + key + "&units=imperial";
            string requestUri = openWeatherMapEndpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}