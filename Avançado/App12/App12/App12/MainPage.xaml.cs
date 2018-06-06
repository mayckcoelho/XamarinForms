using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App12.Model;
using System.ComponentModel.DataAnnotations;

namespace App12
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BtnSalvar.Clicked += delegate
            {
                Pessoa pessoa = new Pessoa()
                {
                    Nome = TxtNome.Text,
                    Email = TxtEmail.Text,
                    CPF = TxtCpf.Text
                };

                var listaRes = new List<ValidationResult>();
                var context = new ValidationContext(pessoa);
                if (!Validator.TryValidateObject(pessoa, context, listaRes, true))
                {
                    LblMsg.TextColor = Color.Red;
                    if (listaRes.Count > 0)
                    {
                        string Errors = string.Empty;
                        listaRes.ForEach(p => Errors += string.Format(p.ErrorMessage + "\n", p.MemberNames));
                        LblMsg.Text = Errors;
                    }
                }
                else
                {
                    LblMsg.TextColor = Color.Green;
                    LblMsg.Text = "OK!";
                }
            };
		}
	}
}
