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

4. Get API Key if you want to use the app for your own use. https://openweathermap.org/appid follow instructions and enter your API key in constants.cs

```
string OpenWeatherMapAPIKey = " ";
```

## Testing

Testing & Test Plan are provided in the excel file included in the repo called Test Plan.xlsx
This test plan includes testing Devices and all of the features in the app

* Windows 10 Home & Pro edition - Laptop & Desktop
* Andriod Emulator 8.1 API 27 & 9.0 in Visual Studio
* Andriod Phone 4.4 Kitkat

## SkiaGrapics

I picked SkiaGraphics because it looked like something we done in Graphics Programming last Semester and would be useful to know for the future

 * Graphics System: SkiaGraphics Engine C++ project made by Google
 * Uses Immediate mode graphics system - When your program calls graphics drawing functions the graphics are quickly rendered
 * Alternative: Retain mode graphics system where graphics are persistant and render whenever necessary
 * Used for 2D graphics and used in Google Chrome, Firefox and Android
 * Draw Graphics on a SKCancasView or a SKGLView
 * SKCanvas is used to call all drawing functions such as Translates, Scales, Rotations etc.
 * SKPaint Draw Attributes: Style, Color, StrokeWidth, StrokeCap, StrokeJoin & Shader
 * [SkiaSharp Microsoft guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/basics/) (Great articles by Microsoft, Spent 8+ Hours learning & fixing errors ended up with a clock at the end)


## Built With

* [Visual Studio](https://visualstudio.microsoft.com/downloads/)
* [Xamarin](https://visualstudio.microsoft.com/xamarin/)

## Author

* [Darren Regan](https://github.com/DarrenRegan)

