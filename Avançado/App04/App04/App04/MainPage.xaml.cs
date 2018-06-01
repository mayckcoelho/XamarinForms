using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App04
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Button myButton = new Button
            {
                Text = "EU SOU DIFERENTE!",
                TextColor = Color.Coral
            };

            Container.Children.Add(myButton);
        }
	}
}
