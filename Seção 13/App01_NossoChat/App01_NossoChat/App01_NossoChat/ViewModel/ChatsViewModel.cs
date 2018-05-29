using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App01_NossoChat.Model;
using App01_NossoChat.Service;
using System.Linq;

namespace App01_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private Chat _selectedChat;
        private List<Chat> _chats;

        public Chat SelectedChat { get { return _selectedChat; } set { _selectedChat = value; OnPropertyChanged(nameof(SelectedChat)); GoPaginaMensagem(value); } }
        public List<Chat> Chats { get { return _chats; } set { _chats = value; OnPropertyChanged(nameof(Chats)); } }

        public Command Adicionar { get; set; }
        public Command Ordenar { get; set; }
        public Command Atualizar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ChatsViewModel()
        {
            Chats = ServiceWS.GetChats();

            Adicionar = new Command(AdicionarAction);
            Ordenar = new Command(OrdenarAction);
            Atualizar = new Command(AtualizarAction);
        }

        private void AdicionarAction()
        {
            ((NavigationPage)App.Current.MainPage).PushAsync(new View.CadastrarChat());
        }

        private void OrdenarAction()
        {
            Chats = Chats.OrderBy(p => p.nome).ToList();
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if (chat != null)
            {
                SelectedChat = null;
                ((NavigationPage)App.Current.MainPage).PushAsync(new View.Mensagens(chat));
            }
        }

        private void AtualizarAction()
        {
            Chats = ServiceWS.GetChats();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
