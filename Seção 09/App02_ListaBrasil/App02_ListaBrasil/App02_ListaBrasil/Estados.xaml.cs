using App02_ListaBrasil.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_ListaBrasil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Estados : ContentPage
	{
		public Estados ()
		{
			InitializeComponent ();
            ListaEstados.ItemsSource = Servico.Servico.GetEstados();
		}

        private void ListaEstados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var estado = e.SelectedItem as Estado;
            Navigation.PushAsync(new Municipios(estado));
        }
    }
}