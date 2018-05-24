using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App01_Mimica.Model;
using Xamarin.Forms;

namespace App01_Mimica.ViewModel
{
    public class ResultadoViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }

        public Command JogarNovamente { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ResultadoViewModel()
        {
            this.Jogo = Data.Data.Jogo;

            JogarNovamente = new Command(JogarJovamenteAction);
        }

        private void JogarJovamenteAction()
        {
            App.Current.MainPage = new View.Inicio();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
