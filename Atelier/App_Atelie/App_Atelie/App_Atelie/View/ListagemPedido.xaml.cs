﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Atelie.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemPedido : ContentPage
	{
		public ListagemPedido ()
		{
			InitializeComponent ();

            BindingContext = new ViewModel.ListagemPedidoViewModel();
		}
	}
}