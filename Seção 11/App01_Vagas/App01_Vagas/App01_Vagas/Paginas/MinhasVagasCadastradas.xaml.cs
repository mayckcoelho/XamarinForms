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
	public partial class MinhasVagasCadastradas : ContentPage
    {
        private List<Vaga> Lista { get; set; }

        public MinhasVagasCadastradas ()
		{
			InitializeComponent ();

            ConsultarVagas();
        }

        private void ConsultarVagas()
        {
            DataBase dataBase = new DataBase();
            Lista = dataBase.Consultar();
            ListaVagas.ItemsSource = Lista;
            lblCount.Text = Lista.Count + " vaga(s) encontrada(s)";
        }

        private void EditarAction(object sender, TappedEventArgs e)
        {
            Label lblEditar = sender as Label;
            var vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new EditarVaga(vaga));
        }

        private void ExcluirAction(object sender, TappedEventArgs e)
        {
            Label lblExcluir = sender as Label;
            var vaga = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Vaga;

            DataBase dataBase = new DataBase();
            dataBase.Exclusao(vaga);
            ConsultarVagas();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
        }
    }
}