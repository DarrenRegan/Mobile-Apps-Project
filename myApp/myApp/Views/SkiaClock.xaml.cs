using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;

/* I picked SKiaGraphics because it looked like something we done in Graphics Programming last Semester and would be useful to know for the future
 * Graphics System: SkiaGraphics Engine C++ project made by Google
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

        //SKPaint Methods/Fields

        SKPaint blackFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };

        //Main
        public SkiaClock ()
		{
			InitializeComponent ();
		}



        


        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //SKCanvas is used to call all drawing functions Translates, Scales, Rotations etc.
            //SKPaint Draw Attributes: Style, Color, StrokeWidth, StrokeCap, StrokeJoin & Shader
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            //Variables for pixels from the event arguments
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Apply Transforms
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 200f);


            //Clear to make a blank canvas
            canvas.Clear(SKColors.CornflowerBlue);



            //Clock Background, centre at 0,0 radius = 100
            canvas.DrawCircle(0, 0, 100, blackFillPaint);

        }
	}
}