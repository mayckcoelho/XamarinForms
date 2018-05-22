using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01_Vagas.Modelos;
using App01_Vagas.Banco;

namespace App01_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastrarVaga : ContentPage
	{
		public CadastrarVaga ()
		{
			InitializeComponent ();
		}

        private void SalvarAction(object sender, EventArgs e)
        {
            Vaga vaga = new Vaga()
            {
                NomeVaga = Vaga.Text,
                Quantidade = short.Parse(Quantidade.Text),
                Empresa = Empresa.Text,
                Cidade = Cidade.Text,
                Salario = double.Parse(Salario.Text),
                Descricao = Descricao.Text,
                TipoContratacao = TipoContratacao.IsToggled ? "PJ" : "CLT",
                Telefone = Telefone.Text,
                Email = Email.Text
            };

            DataBase database = new DataBase();
            database.Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
        }
    }
}