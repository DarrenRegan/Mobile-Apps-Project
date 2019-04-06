using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;

/* Graphics System: SkiaGraphics Engine C++ project made by Google
 * Immediate mode graphics system - When your program calls graphics drawing functions the graphics are quickly rendered
 * Alternative: Retain mode graphics system where graphics are persistant and render whenever necessary
 * Used for 2D graphics and used in Google chrome, Firefox and Android
 * Draw Graphics on a SKCancasView or a SKGLView
 * 
 */

namespace myApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SkiaClock : ContentPage
	{
		public SkiaClock ()
		{
			InitializeComponent ();
		}
	}
}