using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App07
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            // if(Device.OS == TargetPlatform.iOS) está obsoleto
            if (Device.RuntimePlatform == Device.iOS)
                Container.Margin = new Thickness(0, 10, 0, 0);

            // Device.OnPlatform(iOS: () => { }, Android: () => { }... está obsoleto
            Thickness Margin = new Thickness(0, 0, 0, 0);
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Margin = new Thickness(0, 10, 0, 0);
                    break;
            }
            Container.Margin = Margin;

            if (Device.Idiom == TargetIdiom.Tablet)
                Container.BackgroundColor = Color.Green;
        }
	}
}
