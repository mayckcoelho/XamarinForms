using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImagePage : ContentPage
	{
		public ImagePage ()
		{
			InitializeComponent ();
            //ImageOne.IsLoading

            Image imgUSB = new Image();
            imgUSB.Source = ImageSource.FromFile(Device.RuntimePlatform == Device.UWP ? "Imagem/usb.jpg" : "usb.jpg");

            Container.Children.Add(imgUSB);
        }
	}
}