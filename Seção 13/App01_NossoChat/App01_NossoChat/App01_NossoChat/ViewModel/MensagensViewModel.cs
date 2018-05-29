using App01_NossoChat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App01_NossoChat.Service;

namespace App01_NossoChat.ViewModel
{
    public class MensagensViewModel : INotifyPropertyChanged
    {
        private Chat chat;
        private StackLayout stackLayout;

        public Command Atualizar { get; set; }
        public Command BtnEnviar { get; set; }

        private string _txtMensagem;
        private List<Mensagem> _mensagens;

        public string TxtMensagem { get { return _txtMensagem; } set { _txtMensagem = value; OnPropertyChanged(nameof(TxtMensagem)); } }
        public List<Mensagem> Mensagens { get { return _mensagens; } set { _mensagens = value; OnPropertyChanged(nameof(Mensagens)); ShowOnScreen(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public MensagensViewModel(Chat chat, StackLayout stackLayout)
        {
            this.chat = chat;
            this.stackLayout = stackLayout;
            Atualizar = new Command(AtualizarAction);
            BtnEnviar = new Command(EnviarAction);
            AtualizarAction();
        }

        private void AtualizarAction()
        {
            Mensagens = ServiceWS.GetMensagensChat(chat);
        }

        private void EnviarAction()
        {
            var usuarioLogado = Util.UsuarioUtil.GetUsuarioLogado();
            var msg = new Mensagem()
            {
                id_chat = chat.id,
                id_usuario = usuarioLogado.id,
                mensagem = TxtMensagem
            };

            if (ServiceWS.InsertMensagem(msg))
            {
                TxtMensagem = string.Empty;
                stackLayout.Children.Add(CriarMensagemPropria(msg));
            }
        }

        private void ShowOnScreen()
        {
            stackLayout.Children.Clear();
            var usuarioLogado = Util.UsuarioUtil.GetUsuarioLogado();

            if (usuarioLogado == null || Mensagens == null)
                return;

            foreach (var msg in Mensagens)
            {
                if (usuarioLogado.id == msg.id_usuario)
                    stackLayout.Children.Add(CriarMensagemPropria(msg));
                else
                    stackLayout.Children.Add(CriarMensagemOutrosUsuarios(msg));
            }
        }

        private Xamarin.Forms.View CriarMensagemPropria(Mensagem mensagem)
        {
            /*
                <StackLayout Padding="5" BackgroundColor="#5ED055"  HorizontalOptions="End">
                    <Label Text="Olá mundo!" TextColor="White"/>
                </StackLayout>
            */
            var label = new Label() { TextColor = Color.White, Text = mensagem.mensagem };
            var layout = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };

            layout.Children.Add(label);
            return layout;
        }

        private Xamarin.Forms.View CriarMensagemOutrosUsuarios(Mensagem mensagem)
        {
            /*
                <Frame OutlineColor="#5ED055" CornerRadius="0" HorizontalOptions="Start">
                    <StackLayout>
                        <Label Text="Felipe123" FontSize="10" TextColor="#5ED055"/>
                        <Label Text="Olá amigos tudo bem?" TextColor="#5ED055"/>
                    </StackLayout>
                </Frame>
            */
            var labelUsuario = new Label() { FontSize = 10, TextColor = Color.FromHex("#5ED055"), Text = mensagem.usuario.nome };
            var labelMensagem = new Label() { TextColor = Color.FromHex("#5ED055"), Text = mensagem.mensagem };
            var layout = new StackLayout();
            var frame = new Frame() { BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };

            layout.Children.Add(labelUsuario);
            layout.Children.Add(labelMensagem);
            frame.Content = layout;

            return frame;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
