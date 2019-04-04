using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace myApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.rte.ie/weather/24237-galway/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}