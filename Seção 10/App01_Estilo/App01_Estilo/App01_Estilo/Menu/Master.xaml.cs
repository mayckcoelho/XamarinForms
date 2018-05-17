using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Estilo.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoImplicitStylePage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.ImplicitStylePage());
            IsPresented = false;
        }

        private void GoExplicitStylePage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.ExplicitStylePage());
            IsPresented = false;
        }

        private void GoGlobalStylePage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.GlobalStylePage());
            IsPresented = false;
        }

        private void GoInheritStylePage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.InheritStylePage());
            IsPresented = false;
        }

        private void GoDynamicStylePage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.DynamicStylePage());
            IsPresented = false;
        }
    }
}