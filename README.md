# Darren Regan - G00326934 - Mobile Apps Project

The Goal of this project is to learn how to apply a Weather API, Graphics Programming and some other things that i would like to know how to apply in c#/xamarin environment.
In the previous semester we done some API's & Rest using Angular and in Graphics Programming we used Javascript to apply 2D graphics.
I thought this would be very useful to learn for 4th year as i may use Xamarin for my 4th Year Project

## Prerequisites

This application was made in Visual Studio 2017 Community Edition, you may have issues with newer versions of Visual Studio

* Visual Studio 2017
* NuGet Packages found in Installing below
* Git

## Installing

1. Clone the repo

```
git clone https://github.com/DarrenRegan/Mobile-Apps-Project.git
```

2. Click myApp.sln to open the app in Visual Studio

```
Once opened build project to see if there are build errors related to missing NuGet Packages
```

3. Install NuGet Packages if needed

```
* Newtonsoft.JSON
* Xamarin.Forms
* Microsoft.CSharp
* NetStandard.Libary
* sqlite-net-pcl
* SkiaSharp
* SkiaSharp.Views.Forms
```

4. [DONT HAVE TO DO] Get API Key if you want to use the app for your own use. https://openweathermap.org/appid follow instructions and enter your API key in constants.cs

```
string OpenWeatherMapAPIKey = " ";
```

## Testing

Testing & Test Plan are provided in the excel file included in the repo called Test Plan.xlsx
This test plan includes testing Devices and all of the features in the app

* Windows 10 Home & Pro edition - Laptop & Desktop
* Andriod Emulator 8.1 API 27 & 9.0 in Visual Studio
* Andriod Phone 4.4 Kitkat

## Weather API/JSON DATA

Using "http://api.openweathermap.org/data/2.5/weather" to access the weather api using a GET request.
the request has the structure of"http://api.openweathermap.org/data/2.5/weather" ?zip=" + zipCode + ",us&appid=" + key + "&units=metric" in a browser url

Example URL request which is called when user press Get Weather Button
```
        private string GenerateRequestUri(string openWeatherMapEndpoint)
        {
            //This will request the data using the full directory
            //The request should look like this 
            //"http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + key + "&units=metric";
            string requestUri = openWeatherMapEndpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
``` 

* Uses newtonsoft.json
* RestService makes a Httpclient request to website, if website returns a status code between 200-299 you will then receive the JSON data
* Json Data will then be deserialized and added to WeatherData which is used in Mainpage.xaml to receive JSON data to display on user button clicked event  

## WebView

I added a WebView to see how well it would work on mobile devices as i believe WebViews are used in mobile app's for purchasing to get out of high cut in sales that apple and google take when you use there payment methods. Spotify among other apps would only allow an in app webview to make purchases for this reason.

* WebView is quite basic using a [OnAppearing()](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.onappearing?view=xamarin-forms) method to load in url which is set to learnonline.gmit.ie before the page is visible
* Back Navigation was added using GoBack() Method, it uses the property CanGoBack if true it will call goBack to last visited page
* Foward Navigation was added usign GoFoward() Method, it uses the property CanGoFoward if true it will call goFoward to navigate to next visited page
* Reload Navigation is simply calling the WebViewSource which is called moodle and add .reload() to it ie. moodle.reload()

Example of Back & Forward Nav
```
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (moodle.CanGoBack)
            {
                moodle.GoBack();
            }
        void OnForwardButtonClicked
        {
            if (moodle.CanGoForward)
            {
                moodle.GoForward();
            }

```

* [WebView Microsoft Articles](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/webview?tabs=windows#navigation) (Goes indepth into WebViews showing multiple different implementaions, like javascript)

## SkiaSharp

What is SkiaSharp?
 * Graphics System: SkiaGraphics Engine C++ project made by Google
 * Uses Immediate mode graphics system - When your program calls graphics drawing functions the graphics are quickly rendered
 * Alternative: Retain mode graphics system where graphics are persistant and render whenever necessary
 * Used for 2D graphics and used in Google Chrome, Firefox and Android
 * Draw Graphics on a SKCancasView or a SKGLView
 * SKCanvas is used to call all drawing functions such as Translates, Scales, Rotations etc.
 * SKPaint Draw Attributes: Style, Color, StrokeWidth, StrokeCap, StrokeJoin & Shaders
 * [SkiaSharp Microsoft Articles](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/basics/) (Great articles by Microsoft, Spent 8+ Hours learning & fixing errors ended up with a clock at the end)

I picked SkiaSharp because it looked like something we done in Graphics Programming last Semester and would be useful to know for the future
Almost all the code is commented with what it does, i added extra lines to code bits that were hard to understand at first and required googling/videos to understand
A example of this is SKPath.ParseSvgPathData for that clock hands, you can set the variables for placing hand, movement speed of hand etc

Example SKPath.ParseSvgPathData
```
        //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/curves/path-data
        //Scalable Vector Graphics - Hour & Minute hand path using curves
        //Each String is a one letter command or coordinates
        //M = Move, C = Cubic Bezier Line, L = Line, Z = Closes path at the end
        SKPath hourHandPath = SKPath.ParseSvgPathData(
            "M 0 -60 C 0 -30 20 -30 5 -20 L 5 0 C 5 7.5 -5 7.5 -5 0 L -5 -20 C -20 -30 0 -30 0 -60");
        SKPath minuteHandPath = SKPath.ParseSvgPathData(
            "M 0 -80 C 0 -75 0 -70 2.5 -60 L 2.5 0 C 2.5 5 -2.5 5 -2.5 0 L -2.5 -60 C 0 -70 0 -75 0 -80");

```

In our Graphics Programming module last semester we need something quite similar to SkiaSharp using javascript
This code is almost identical to what we did in javascript so it's quite easy to do
Everything else is commented apprioately for what it draws, rotates etc.

Example of Drawing Cat Ears, Whispers and Eyes
```
//Draw Cat Ears and Eyes
            //When i = 0, scale transform has an x cord of -1 (so it flips everything around the verticle axis
            //When i = 1, scale transform will be normal
            for (int i = 0; i < 2; i++)
            {
                canvas.Save();
                canvas.Scale(2 * i - 1, 1);

                //Ears
                canvas.Save();
                canvas.Translate(-65, -255);
                canvas.DrawPath(catEarPath, blackFillPaint);
                canvas.Restore();

                //Eyes
                canvas.Save();
                canvas.Translate(10, -170);
                canvas.DrawPath(catEyePath, whiteFillPaint);
                canvas.DrawPath(catPupilPath, blackFillPaint);
                canvas.Restore();

                //Whispers
                canvas.DrawLine(10, -120, 100, -100, whiteStrokePaint);
                canvas.DrawLine(10, -125, 100, -120, whiteStrokePaint);
                canvas.DrawLine(10, -130, 100, -140, whiteStrokePaint);
                canvas.DrawLine(10, -135, 100, -160, whiteStrokePaint);

                canvas.Restore();

            }

```



## Built With

* [Visual Studio](https://visualstudio.microsoft.com/downloads/)
* [Xamarin](https://visualstudio.microsoft.com/xamarin/)

## Author

* [Darren Regan](https://github.com/DarrenRegan)

