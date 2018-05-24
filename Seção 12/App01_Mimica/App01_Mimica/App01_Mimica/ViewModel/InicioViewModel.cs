using System;
using System.Collections.Generic;
using System.Text;
using App01_Mimica.Model;
using System.ComponentModel;
using Xamarin.Forms;

namespace App01_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }

        public string MsgErro { get; set; }

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo
            {
                Grupo1 = new Grupo(),
                Grupo2 = new Grupo()
            };

            Jogo.TempoPalavra = 120;
            Jogo.Rodadas = 7;
        }

        private void IniciarJogo()
        {
            string erro = string.Empty;
            if (Jogo.TempoPalavra < 10)
                erro += "O tempo mínimo para o tempo da palavra é 10 segundos.";
            if (Jogo.TempoPalavra <= 0)
                erro += "O valor mínimo para a rodada é 1.";

            if (erro.Length > 0)
            {
                MsgErro = erro;
                OnPropertyChanged(nameof(MsgErro));
            }
            else
            {

                Data.Data.Jogo = Jogo;
                Data.Data.RodadaAtual = 1;

                App.Current.MainPage = new View.Jogo(Data.Data.Jogo.Grupo1);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
