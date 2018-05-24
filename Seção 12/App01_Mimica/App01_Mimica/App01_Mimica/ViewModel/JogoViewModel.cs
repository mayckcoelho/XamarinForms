using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App01_Mimica.Model;

namespace App01_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        private byte _palavraPontuacao;
        private string _palavra;
        private string _textoContagem;

        private bool _isVisibleContainerContagem;
        private bool _isVisibleContainerIniciar;
        private bool _isVisibleBtnMostrar;

        public Grupo Grupo { get; set; }

        public byte PalavraPontuacao
        {
            get { return _palavraPontuacao; }
            set { _palavraPontuacao = value; OnPropertyChanged(nameof(PalavraPontuacao)); }
        }
        public string Palavra
        {
            get { return _palavra; }
            set { _palavra = value; OnPropertyChanged(nameof(Palavra)); }
        }
        public string TextoContagem
        {
            get { return _textoContagem; }
            set { _textoContagem = value; OnPropertyChanged(nameof(TextoContagem)); }
        }

        public bool IsVisibleContainerContagem
        {
            get { return _isVisibleContainerContagem; }
            set { _isVisibleContainerContagem = value; OnPropertyChanged(nameof(IsVisibleContainerContagem)); }
        }
        public bool IsVisibleContainerIniciar
        {
            get { return _isVisibleContainerIniciar; }
            set { _isVisibleContainerIniciar = value; OnPropertyChanged(nameof(IsVisibleContainerIniciar)); }
        }
        public bool IsVisibleBtnMostrar
        {
            get { return _isVisibleBtnMostrar; }
            set { _isVisibleBtnMostrar = value; OnPropertyChanged(nameof(IsVisibleBtnMostrar)); }
        }

        public Command MostrarBalavra { get; set; }
        public Command Iniciar { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public JogoViewModel(Grupo grupo)
        {
            Grupo = grupo;

            IsVisibleContainerContagem = false;
            IsVisibleContainerIniciar = false;
            IsVisibleBtnMostrar = true;

            Palavra = "**********";

            MostrarBalavra = new Command(MostrarPalavraAction);
            Iniciar = new Command(IniciarAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
        }

        Random rd = new Random();
        private void MostrarPalavraAction()
        {
            switch (Data.Data.Jogo.NivelNumerico)
            {
                case 0:
                    int nivel = rd.Next(0, 2);
                    Palavra = Data.Data.Palavras[nivel][rd.Next(0, Data.Data.Palavras[nivel].Length)];
                    PalavraPontuacao = (byte)(nivel == 0 ? 1 : (nivel == 1 ? 3 : 5));
                    break;
                case 1:
                    Palavra = Data.Data.Palavras[0][rd.Next(0, Data.Data.Palavras[0].Length)];
                    PalavraPontuacao = 1;
                    break;
                case 2:
                    Palavra = Data.Data.Palavras[1][rd.Next(0, Data.Data.Palavras[1].Length)];
                    PalavraPontuacao = 3;
                    break;
                case 3:
                    Palavra = Data.Data.Palavras[2][rd.Next(0, Data.Data.Palavras[2].Length)];
                    PalavraPontuacao = 5;
                    break;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Palavra)));
            IsVisibleBtnMostrar = false;
            IsVisibleContainerIniciar = true;
        }

        private void IniciarAction()
        {
            IsVisibleContainerIniciar = false;
            IsVisibleContainerContagem = true;

            // TODO - quando o tempo terminar, parar a contagem
            int i = Data.Data.Jogo.TempoPalavra;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TextoContagem = i.ToString();
                i--;

                if (i < 0)
                    TextoContagem = "Esgotou o tempo";

                return true;
            });
        }

        private void AcertouAction()
        {
            Grupo.Pontuacao += PalavraPontuacao;
            GoProximoGrupo();
        }

        private void ErrouAction()
        {
            GoProximoGrupo();
        }

        private void GoProximoGrupo()
        {
            Grupo grupo;
            if (Data.Data.Jogo.Grupo1 == Grupo)
                grupo = Data.Data.Jogo.Grupo2;
            else
            {
                Data.Data.RodadaAtual = (short)(Data.Data.RodadaAtual + 1);
                grupo = Data.Data.Jogo.Grupo1;
            }

            if (Data.Data.RodadaAtual > Data.Data.Jogo.Rodadas)
                App.Current.MainPage = new View.Resultado();
            else
                App.Current.MainPage = new View.Jogo(grupo);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
