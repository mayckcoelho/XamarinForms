using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App02_SOAPClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            int Num1T = int.Parse(Num1.Text);
            int Num2T = int.Parse(Num2.Text);

            TxtResultado.Text = DependencyService.Get<IServiceSOAP>().Somar(Num1T, Num2T);
        }
    }
}
