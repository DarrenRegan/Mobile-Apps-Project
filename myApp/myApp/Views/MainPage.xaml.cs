using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;


namespace myApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}