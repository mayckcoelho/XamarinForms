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
	public partial class ViewCellPage : ContentPage
	{
		public ViewCellPage ()
		{
			InitializeComponent ();

            var lista = new List<Funcionario>
            {
                new Funcionario() { Foto = "perfil.png", Nome = "José", Cargo = "Presidente" },
                new Funcionario() { Foto = "perfil.png", Nome = "Maria", Cargo = "Gerente de Vendas" },
                new Funcionario() { Foto = "perfil.png", Nome = "Elaine", Cargo = "Gerente de Marketing" },
                new Funcionario() { Foto = "perfil.png", Nome = "Filipe", Cargo = "Entregador" },
                new Funcionario() { Foto = "perfil.png", Nome = "João", Cargo = "Vendedor" }
            };

            ListaFuncionario.ItemsSource = lista;
        }
	}
}