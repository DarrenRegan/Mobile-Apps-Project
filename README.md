# Darren Regan - G00326934 - Mobile Apps Project

The Goal of this project is to learn how to apply a Weather API, Graphics Programming and some other things that i would like to know how to apply in c#/xamarin environment
In the previous semester we done some API's & Rest using Angular and in Graphics Programming we used Javascript to apply 2D graphics
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
* NetStanard.Libary
* sqlite-net-pcl
* SkiaSharp
* SkiaSharp.Views.Forms
```

4. Get API Key if you want to use the app for your own use. https://openweathermap.org/appid follow instructions and enter your API key in constants.cs

```
string OpenWeatherMapAPIKey = " ";
```

## SkiaGrapics
 ### I picked SkiaGraphics because it looked like something we done in Graphics Programming last Semester and would be useful to know for the future
 * Graphics System: SkiaGraphics Engine C++ project made by Google
 * Uses Immediate mode graphics system - When your program calls graphics drawing functions the graphics are quickly rendered
 * Alternative: Retain mode graphics system where graphics are persistant and render whenever necessary
 * Used for 2D graphics and used in Google Chrome, Firefox and Android
 * Draw Graphics on a SKCancasView or a SKGLView
 * SKCanvas is used to call all drawing functions such as Translates, Scales, Rotations etc.
 * SKPaint Draw Attributes: Style, Color, StrokeWidth, StrokeCap, StrokeJoin & Shader



## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.




## Runni

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
