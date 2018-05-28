using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App01_NossoChat.Model;
using App01_NossoChat.Service;
using Newtonsoft.Json;

namespace App01_NossoChat.ViewModel
{
    public class PaginaInicialViewModel : INotifyPropertyChanged
    {
        private string _nome;
        private string _senha;
        private string _mensagem;

        public string Nome { get { return _nome; } set { _nome = value; OnPropertyChanged(nameof(Nome)); } }
        public string Senha { get { return _senha; } set { _senha = value; OnPropertyChanged(nameof(Senha)); } }
        public string Mensagem { get { return _mensagem; } set { _mensagem = value; OnPropertyChanged(nameof(Mensagem)); } }

        public Command AcessarCadastrar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PaginaInicialViewModel()
        {
            AcessarCadastrar = new Command(AcessarCadastrarAction);
        }

        public void AcessarCadastrarAction()
        {
            var usuario = new Usuario
            {
                nome = Nome,
                password = Senha
            };

            var usuarioLogado = ServiceWS.GetUsuario(usuario);
            if (usuarioLogado == null)
                Mensagem = "Senha incorreta";
            else
            {
                Util.UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor = Color.FromHex("#5ED055"), BarTextColor = Color.White };
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
