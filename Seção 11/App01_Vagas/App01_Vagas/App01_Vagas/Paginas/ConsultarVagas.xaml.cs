using App01_Vagas.Banco;
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
	public partial class ConsultarVagas : ContentPage
	{
        private List<Vaga> Lista { get; set; }

		public ConsultarVagas ()
		{
			InitializeComponent ();

            DataBase dataBase = new DataBase();
            Lista = dataBase.Consultar();
            ListaVagas.ItemsSource = Lista;
            lblCount.Text = Lista.Count + " vaga(s) encontrada(s)";
		}

        private void GoCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        private void MaisDetalheAction(object sender, EventArgs e)
        {
            Label lblDetalhe = sender as Label;
            var vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new DetalharVaga(vaga));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
        }
    }
}