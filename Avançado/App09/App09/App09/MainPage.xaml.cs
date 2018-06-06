using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App09
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            LblNome.Text = Properties.Resources.LBL_NOME;
            TxtNome.Placeholder = Properties.Resources.TXT_PH_NOME;
            BtnSalvar.Text = Properties.Resources.BTN_SALVAR;
		}
	}
}
