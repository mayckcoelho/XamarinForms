using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App01_NossoChat
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new View.PaginaInicial();
		}

		protected override void OnStart ()
		{
            var prop = this.Properties;
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
