using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App08
{
	public partial class MainPage : ContentPage
	{
        int count = 0;
		public MainPage()
		{
			InitializeComponent();

            // Gesture
            // Tap - Toque/Clique
            // Pinch - Pinça/Zoom
            // Pan - Arrastar
            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += PanGestureRecognizer_PanUpdated;
            MyLabel.GestureRecognizers.Add(pan);
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            count++;
            //DisplayAlert("Tapped", "Fui tapeado " + count + " vezes!", "OK");
            //MyBox.TranslateTo(200, 350, 1000, Easing.BounceOut);
            //MyBox.ScaleTo(2, 1000);
            //MyBox.FadeTo(0.5, 1000);
            //MyBox.RotateTo(45, 1000);

            var anim = new Animation(v => MyBox.WidthRequest = v, 50, 100);
            anim.Commit(this, "animation", length: 1000);
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
            {
                Rectangle rect = new Rectangle(e.TotalX, e.TotalY, 200, 25);

                AbsoluteLayout.SetLayoutBounds(MyLabel, rect);
                AbsoluteLayout.SetLayoutFlags(MyLabel, AbsoluteLayoutFlags.None);
            }
        }
    }
}
