using App01_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaVagas : ContentPage
	{
		public ConsultaVagas ()
		{
			InitializeComponent ();
		}

        private void GoCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroVagas());
        }

        private void GoMinhasVagas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        private void MaisDetalheAction(object sender, EventArgs e)
        {
            Label lblDetalhe = sender as Label;
            var vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new DetalheVagas(vaga));
        }
    }
}