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
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            moodle.Source = "https://learnonline.gmit.ie";
        }

        /// <summary>
        /// When user clicks back button in webview navPage will go back one page. User can go back all the way to start with multiple press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (moodle.CanGoBack)
            {
                moodle.GoBack();
            }
            else
            {
                await Navigation.PopAsync(); // closes the in-app browser view.
            }
        }

        /// <summary>
        /// When User clicks reload NavPage will reload the current page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnReloadButtonClicked(object sender, EventArgs e)
        {
            moodle.Reload();
        }

        /// <summary>
        /// When user clicks foward NavPage should go foward one page using CanGoFoward & GoFoward() methods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (moodle.CanGoForward)
            {
                moodle.GoForward();
            }
        }
    }
}