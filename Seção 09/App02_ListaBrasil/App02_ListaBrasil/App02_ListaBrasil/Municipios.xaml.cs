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
	public partial class Municipios : ContentPage
	{
        private List<Municipio> ListaInternaMunicipios { get; set; }
        private List<Municipio> ListaFiltradaMunicipios { get; set; }

        public Municipios (Estado estado)
		{
			InitializeComponent ();
            ListaInternaMunicipios = Servico.Servico.GetMunicipios(estado.id);
            ListaMunicipios.ItemsSource = ListaInternaMunicipios;
		}

        private void TxtMunicipio_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaFiltradaMunicipios = ListaInternaMunicipios.Where(p => p.nome.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
            ListaMunicipios.ItemsSource = ListaFiltradaMunicipios;
        }
    }
}