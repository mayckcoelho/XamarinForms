using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Cell.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoTextCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.TextCellPage());
            IsPresented = false;
        }

        private void GoImageCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.ImageCellPage());
            IsPresented = false;
        }

        private void GoEntryCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.EntryCellPage());
            IsPresented = false;
        }

        private void GoSwitchCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.SwitchCellPage());
            IsPresented = false;
        }

        private void GoViewCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.ViewCellPage());
            IsPresented = false;
        }

        private void GoListViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.ListViewPage());
            IsPresented = false;
        }

        private void GoListViewButtonPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Pagina.ListViewButtonPage());
            IsPresented = false;
        }
    }
}