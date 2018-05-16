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
	public partial class TextCellPage : ContentPage
	{
		public TextCellPage ()
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
	}
}