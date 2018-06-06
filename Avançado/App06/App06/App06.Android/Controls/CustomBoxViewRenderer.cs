using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App06.Controls;
using App06.Droid.Controls;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRenderer))]
namespace App06.Droid.Controls
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        public CustomBoxViewRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var control =(CustomBoxView)Element;

            Paint p = new Paint
            {
                StrokeWidth = (float)control.Espessura,
            };

            canvas.DrawRect(new Rect(0, 0, 200, 200), p);

            p.Color = Android.Graphics.Color.White;

            canvas.DrawLine(100, 0, 100, 200, p);

            canvas.DrawLine(0, 100, 200, 100, p);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Invalidate();
        }
    }
}