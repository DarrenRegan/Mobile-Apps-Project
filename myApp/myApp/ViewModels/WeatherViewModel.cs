using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace myApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        public WeatherViewModel()
        {
            Title = "Weather";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.rte.ie/weather/24237-galway/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
