using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using App01_Vagas.Banco;
using App01_Vagas.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace App01_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBanco = System.IO.Path.Combine(caminhoPasta, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}