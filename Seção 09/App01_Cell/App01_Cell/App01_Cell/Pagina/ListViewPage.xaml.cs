using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01_Cell.Modelo;

namespace App01_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            var lista = new List<Funcionario>
            {
                new Funcionario() { Nome = "José", Cargo = "Presidente" },
                new Funcionario() { Nome = "Maria", Cargo = "Gerente de Vendas" },
                new Funcionario() { Nome = "Elaine", Cargo = "Gerente de Marketing" },
                new Funcionario() { Nome = "Filipe", Cargo = "Entregador" },
                new Funcionario() { Nome = "João", Cargo = "Vendedor" }
            };

            ListaFuncionario.ItemsSource = lista;
        }

        private void ListaFuncionario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var func = (Funcionario)e.SelectedItem;
            Navigation.PushAsync(new Detalhe.DetailPage(func));
        }

        private void MenuItem1_Clicked(object sender, EventArgs e)
        {
            var func = ((MenuItem)sender).CommandParameter as Funcionario;
            DisplayAlert("AVISO", func.Nome + " está de férias.", "OK");
        }

        private void MenuItem2_Clicked(object sender, EventArgs e)
        {
            var func = ((MenuItem)sender).CommandParameter as Funcionario;
            DisplayAlert("AVISO", func.Nome + " recebeu o abono.", "OK");
        }
    }
}