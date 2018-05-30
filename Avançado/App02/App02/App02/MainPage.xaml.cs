using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App02
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            ListaFuncionarios.ItemsSource = GetFuncionarios();
		}

        public class Grupo : List<Funcionario>
        {
            public string Titulo { get; set; }
            public string TituloCurto { get; set; }
            public string Descricao { get; set; }

            public Grupo(string titulo, string tituloCurto, string descricao)
            {
                this.Titulo = titulo;
                this.TituloCurto = tituloCurto;
                this.Descricao = descricao;
            }
        }

        public class Funcionario
        {
            public string Nome { get; set; }
            public int RankEficiencia{ get; set; }
            public bool IsObrigatorio { get; set; }
        }

        private List<Grupo> GetFuncionarios()
        {
            return new List<Grupo>()
            {
                new Grupo("Presidente", "CEO", "Presidente da Empresa")
                {
                    new Funcionario() { Nome = "Mayck", IsObrigatorio = true, RankEficiencia = 8 }
                },
                new Grupo("Diretores", "Dir.", "Diretores da Empresa")
                {
                    new Funcionario() { Nome = "José", IsObrigatorio = true, RankEficiencia = 8 },
                    new Funcionario() { Nome = "João", IsObrigatorio = false }
                },
                new Grupo("Gerentes", "Ger.", "Gerentes de Departamentos")
                {
                    new Funcionario() { Nome = "Maria", IsObrigatorio = true, RankEficiencia = 5 },
                    new Funcionario() { Nome = "Felipe", IsObrigatorio = false },
                    new Funcionario() { Nome = "Judas", IsObrigatorio = false }
                },
                new Grupo("Colaboradores", "Col.", "Colaboradores da Empresa")
                {
                    new Funcionario() { Nome = "Pedro", IsObrigatorio = true, RankEficiencia = 8 },
                    new Funcionario() { Nome = "Simão", IsObrigatorio = true, RankEficiencia = 8 },
                    new Funcionario() { Nome = "Danilo", IsObrigatorio = true, RankEficiencia = 8 },
                    new Funcionario() { Nome = "Jéssica", IsObrigatorio = false },
                    new Funcionario() { Nome = "Elen", IsObrigatorio = false },
                    new Funcionario() { Nome = "Débora", IsObrigatorio = false },
                    new Funcionario() { Nome = "Augusto", IsObrigatorio = false },
                    new Funcionario() { Nome = "Antonio", IsObrigatorio = false },
                    new Funcionario() { Nome = "Danilo", IsObrigatorio = true, RankEficiencia = 8 },
                }
            };
        }
	}
}
