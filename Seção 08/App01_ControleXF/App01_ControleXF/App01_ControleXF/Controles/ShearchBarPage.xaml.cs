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
	public partial class ShearchBarPage : ContentPage
	{
        private List<string> empresasTI;

        public ShearchBarPage ()
		{
			InitializeComponent ();

            empresasTI = new List<string>
            {
                "Microsoft",
                "Apple",
                "Oracle",
                "IBM",
                "SAP",
                "Google",
                "Uber",
                "99Taxi"
            };

            Preencher(empresasTI);
        }

        private void Preencher(List<string> empresasTI)
        {
            ListResult.Children.Clear();
            foreach (var emp in empresasTI)
            {
                ListResult.Children.Add(new Label { Text = emp });
            }
        }

        private void Pesquisar(object sender, EventArgs args)
        {
            var resultado = empresasTI.Where(a => a.Contains(((SearchBar)sender).Text)).ToList();
            Preencher(resultado);
        }
	}
}