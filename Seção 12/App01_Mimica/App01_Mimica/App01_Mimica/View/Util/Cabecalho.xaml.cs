using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Mimica.View.Util
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cabecalho : ContentView
	{
		public Cabecalho ()
		{
			InitializeComponent ();
            BindingContext = new ViewModel.CabecalhoViewModel();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var viewModel = this.BindingContext as ViewModel.CabecalhoViewModel;
            if (viewModel.Sair.CanExecute(null))
                viewModel.Sair.Execute(null);
        }
    }
}