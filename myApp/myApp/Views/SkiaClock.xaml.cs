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

        //SKPaint Fields

        SKPaint blackFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };

        //Clock hands
        SKPaint whiteStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            StrokeWidth = 2,
            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
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

            //Get DateTime
            DateTime dateTime = DateTime.Now;



            //Clear to make a blank canvas
            canvas.Clear(SKColors.CornflowerBlue);

            //Clock Background, centre at 0,0 radius = 100
            //Draws Black Circle
            canvas.DrawCircle(0, 0, 100, blackFillPaint);

            //Hour Hand
            //Rotate Hand 30 Degrees per hour + 1 degree for every 2 minutes
            canvas.Save(); //Call save before transforms
            canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
            whiteStrokePaint.StrokeWidth = 15;
            canvas.DrawLine(0, 0, 0, -50, whiteStrokePaint); //Pos 12 o'Clock
            canvas.Restore(); //Call Restore after done

            //Minute Hand
            //Rotate 6 Degrees per minute 1 degree every 1 second
            canvas.Save();
            canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
            whiteStrokePaint.StrokeWidth = 10;
            canvas.DrawLine(0, 0, 0, -70, whiteStrokePaint);
            canvas.Restore();

            //Second Hand
            canvas.Save();
            float seconds = dateTime.Second + dateTime.Millisecond / 1000f;
            canvas.RotateDegrees(6 * seconds);
            whiteStrokePaint.StrokeWidth = 2;
            canvas.DrawLine(0, 10, 0, -80, whiteStrokePaint);
            canvas.Restore();

        }
	}
}