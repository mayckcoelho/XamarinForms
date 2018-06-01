using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App05
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void MyControl_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Oi, eu sou um evento!", "Fui executado!", "OK");
        }
    }
}
