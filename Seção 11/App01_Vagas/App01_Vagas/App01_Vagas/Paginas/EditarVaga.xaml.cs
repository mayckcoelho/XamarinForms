using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01_Vagas.Banco;
using App01_Vagas.Modelos;

namespace App01_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarVaga : ContentPage
	{
        private Vaga Vaga { get; set; }

		public EditarVaga (Vaga vaga)
		{
			InitializeComponent ();
            this.Vaga = vaga;

            NomeVaga.Text = vaga.NomeVaga;
            Quantidade.Text = vaga.Quantidade.ToString();
            Empresa.Text = vaga.Empresa;
            Cidade.Text = vaga.Cidade;
            Salario.Text = vaga.Salario.ToString();
            Descricao.Text = vaga.Descricao;
            TipoContratacao.IsToggled = vaga.TipoContratacao == "PJ";
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
        }

        private void SalvarAction(object sender, EventArgs e)
        {
            Vaga.NomeVaga = NomeVaga.Text;
            Vaga.Quantidade = short.Parse(Quantidade.Text);
            Vaga.Empresa = Empresa.Text;
            Vaga.Cidade = Cidade.Text;
            Vaga.Salario = double.Parse(Salario.Text);
            Vaga.Descricao = Descricao.Text;
            Vaga.TipoContratacao = TipoContratacao.IsToggled ? "PJ" : "CLT";
            Vaga.Telefone = Telefone.Text;
            Vaga.Email = Email.Text;

            DataBase database = new DataBase();
            database.Atualizacao(Vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }
    }
}