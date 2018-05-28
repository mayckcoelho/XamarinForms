﻿using App01_NossoChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_NossoChat.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mensagens : ContentPage
	{
		public Mensagens (Chat chat)
		{
			InitializeComponent ();

            BindingContext = new ViewModel.MensagensViewModel(chat, SLMensagemContainer);
		}
	}
}