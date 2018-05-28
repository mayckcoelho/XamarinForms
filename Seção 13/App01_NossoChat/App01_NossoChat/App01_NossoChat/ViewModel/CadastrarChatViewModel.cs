using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App01_NossoChat.Model;
using App01_NossoChat.Service;
using System.ComponentModel;

namespace App01_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        private string _mensagem;

        public string Nome { get; set; }
        public Command Cadastrar { get; set; }
        public string Mensagem { get { return _mensagem; } set { _mensagem = value; OnPropertyChanged(nameof(Mensagem)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public CadastrarChatViewModel()
        {
            Cadastrar = new Command(CadastrarAction);
        }

        private void CadastrarAction()
        {
            var chat = new Chat() { nome = Nome };
            if (ServiceWS.InsertChat(chat))
            {
                ((NavigationPage)App.Current.MainPage).PopAsync();
                var view = ((NavigationPage)App.Current.MainPage).RootPage as View.Chats;
                var viewModel = view.BindingContext as ChatsViewModel;

                if (viewModel.Atualizar.CanExecute(null))
                    viewModel.Atualizar.Execute(null);
            }
            else
                Mensagem = "Ocorreu um erro no cadastro";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
