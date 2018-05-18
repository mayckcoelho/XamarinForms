using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using App01_Vagas.Banco;
using App01_Vagas.iOS.Banco;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace App01_Vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoPasta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string caminhoBiblioteca = Path.Combine(caminhoPasta, "..", "Library");
            string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}