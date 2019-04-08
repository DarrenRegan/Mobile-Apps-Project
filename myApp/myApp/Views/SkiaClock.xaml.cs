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

        SKPaint whiteFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        SKPaint blackStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 20,
            StrokeCap = SKStrokeCap.Round
        };

        SKPaint greenFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Green
        };

        SKPaint goldFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Gold
        };

        SKPaint silverFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Silver
        };

        //Background image
        SKPaint backgroundFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill
        };

        //SKPaths for Cat
        SKPath catEarPath = new SKPath();
        SKPath catEyePath = new SKPath();
        SKPath catPupilPath = new SKPath();
        SKPath catTailPath = new SKPath();

        //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/curves/path-data
        //Scalable Vector Graphics - Hour & Minute hand path using curves
        //Each String is a one letter command or coordinates
        //M = Move, C = Cubic Bezier Line, L = Line, Z = Closes path at the end
        SKPath hourHandPath = SKPath.ParseSvgPathData(
            "M 0 -60 C 0 -30 20 -30 5 -20 L 5 0 C 5 7.5 -5 7.5 -5 0 L -5 -20 C -20 -30 0 -30 0 -60");
        SKPath minuteHandPath = SKPath.ParseSvgPathData(
            "M 0 -80 C 0 -75 0 -70 2.5 -60 L 2.5 0 C 2.5 5 -2.5 5 -2.5 0 L -2.5 -60 C 0 -70 0 -75 0 -80");

        //Constructor of main class
        public SkiaClock ()
		{
			InitializeComponent ();

            //Paths of cat
       
            //Creates a triangle
            catEarPath.MoveTo(0, 0);
            catEarPath.LineTo(0, 75);
            catEarPath.LineTo(100, 75);
            catEarPath.Close();

            //Cats eye using arcs
            catEyePath.MoveTo(0, 0);
            catEyePath.ArcTo(50, 50, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 50, 0);
            catEyePath.ArcTo(50, 50, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 0, 0);
            catEyePath.Close();

            //Cats pupil using arcs
            catPupilPath.MoveTo(25, -5);
            catPupilPath.ArcTo(6, 6, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 25, 5);
            catPupilPath.ArcTo(6, 6, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 25, -5);
            catPupilPath.Close();

            //Cat tail using a curve
            catTailPath.MoveTo(0, 100);
            catTailPath.CubicTo(50, 200, 0, 250, -50, 200);

            //Create Shader - Bring in background image
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("myApp.sandClockBackground.png"))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            using (SKBitmap bitmap = SKBitmap.Decode(skStream))
            using (SKShader shader = SKShader.CreateBitmap(bitmap, SKShaderTileMode.Mirror, SKShaderTileMode.Mirror))
            {
                backgroundFillPaint.Shader = shader;
            }

            //Starts a timer which the clock uses to move the hands
            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {
                canvasView.InvalidateSurface();
                return true;
            });

            
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            //SKCanvas is used to call all drawing functions Translates, Scales, Rotations etc.
            //SKPaint Draw Attributes: Style, Color, StrokeWidth, StrokeCap, StrokeJoin & Shader
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            //Clear to make a blank canvas
            canvas.Clear(SKColors.CornflowerBlue);

            //Variables for pixels from the event arguments
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Paint background with an image
            canvas.DrawPaint(backgroundFillPaint);

            //Apply Transforms
            canvas.Translate(width / 2, height / 2);
            //canvas.Scale(width / 200f);
            canvas.Scale(Math.Min(width / 210f, height / 520f));

            //Get DateTime
            DateTime dateTime = DateTime.Now;

            //Cat Head
            canvas.DrawCircle(0, -160, 75, blackFillPaint);

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

            //Moving the tail
            //Calcs time that moves Sin from -1 to 1 every second
            float t = (float)Math.Sin((dateTime.Second % 2 + dateTime.Millisecond / 1000.0) * Math.PI); 
            //Recreates Path for creating the tail
            //But this time the coordinates are based the on the current time instead of a fixed value
            catTailPath.Reset();
            catTailPath.MoveTo(0, 100);
            SKPoint point1 = new SKPoint(-50 * t, 200);
            SKPoint point2 = new SKPoint(0, 250 - Math.Abs(50 * t));
            SKPoint point3 = new SKPoint(50 * t, 250 - Math.Abs(75 * t));
            catTailPath.CubicTo(point1, point2, point3);

            //Draw Tail
            canvas.DrawPath(catTailPath, blackStrokePaint);

            //Clock Background, centre at 0,0 radius = 100
            //Draws Black Circle
            canvas.DrawCircle(0, 0, 100, blackFillPaint);

            //Hour and Minute Marks using dots
            //For every 6 degrees draw a dot, so 60 dots
            for (int angle = 0; angle < 360; angle += 6)
            {
                canvas.DrawCircle(0, -90, angle % 30 == 0 ? 4 : 2, whiteFillPaint);
                canvas.RotateDegrees(6);
            }

            //Hour Hand
            //Rotate Hand 30 Degrees per hour + 1 degree for every 2 minutes
            canvas.Save(); //Call save before transforms
            canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
            canvas.DrawPath(hourHandPath, silverFillPaint);
            canvas.DrawPath(hourHandPath, whiteStrokePaint);
            canvas.Restore(); //Call Restore after done

            //Minute Hand
            //Rotate 6 Degrees per minute 1 degree every 10 seconds
            canvas.Save();
            canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
            canvas.DrawPath(minuteHandPath, silverFillPaint);
            canvas.DrawPath(minuteHandPath, whiteStrokePaint);
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