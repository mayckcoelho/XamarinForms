using App01_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewButtonPage : ContentPage
	{
		public ListViewButtonPage ()
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            var func = ((Button)sender).CommandParameter as Funcionario;
            DisplayAlert("AVISO", func.Nome + " está de férias.", "OK");
        }
    }
}