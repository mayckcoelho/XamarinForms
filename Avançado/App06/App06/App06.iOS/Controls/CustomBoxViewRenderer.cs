using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using App06.Controls;
using App06.iOS.Controls;
using CoreGraphics;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRenderer))]
namespace App06.iOS.Controls
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        public override void Draw(CGRect rect)
        {
            //base.Draw(rect);
            var control = (CustomBoxView)Element;

            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetStrokeColor(new CGColor(0, 0, 0));
                context.SetLineWidth((float)control.Espessura);

                context.AddRect(new CGRect(0, 0, 200, 200));
                context.DrawPath(CGPathDrawingMode.Stroke);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomBoxView.EspessuraProperty.PropertyName)
            {
                SetNeedsDisplay();
            }
            //base.OnElementPropertyChanged(sender, e);
        }
    }
}