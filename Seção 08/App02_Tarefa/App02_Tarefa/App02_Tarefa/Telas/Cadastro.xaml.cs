using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App02_Tarefa.Modelos;

namespace App02_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        private byte Prioridade { get; set; }

		public Cadastro ()
		{
			InitializeComponent ();
		}

        private void PrioridadeSelectAction(object sender, TappedEventArgs args)
        {
            var Stacks = SLPrioridades.Children;

            foreach(var stack in Stacks)
            {
                Label LblPrioridade = ((StackLayout)stack).Children[1] as Label;
                LblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            string Prioridade = Source.File.ToString().Replace("Resources/", "").Replace(".png", "").Replace("p", "");
            this.Prioridade = byte.Parse(Prioridade);
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            bool ErroExiste = false;
            if (!(TxtNome.Text.Trim().Length > 0))
            {
                ErroExiste = true;
                DisplayAlert("ERRO", "Nome não preenchido!", "OK");
            }

            if (!(Prioridade > 0))
            {
                ErroExiste = true;
                DisplayAlert("ERRO", "Prioridade não foi informada!", "OK");
            }

            if (!ErroExiste)
            {
                Tarefa tarefa = new Tarefa
                {
                    Nome = TxtNome.Text.Trim(),
                    Prioridade = this.Prioridade
                };

                new GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}