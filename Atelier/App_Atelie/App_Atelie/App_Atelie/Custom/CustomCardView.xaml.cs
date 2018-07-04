using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Atelie.Custom
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomCardView : ContentView
	{
		public CustomCardView ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty TituloProperty = BindableProperty.Create(
            propertyName: nameof(Titulo),
            returnType: typeof(string),
            declaringType: typeof(CustomCardView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TituloProperty_Changed
            );

        public string Titulo
        {
            get { return GetValue(TituloProperty).ToString(); }
            set { SetValue(TituloProperty, value); }
        }

        private static void TituloProperty_Changed(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = bindable as CustomCardView;
            myControl.titulo.Text = newValue.ToString();
        }

        public static readonly BindableProperty SubTituloProperty = BindableProperty.Create(
            propertyName: nameof(Titulo),
            returnType: typeof(string),
            declaringType: typeof(CustomCardView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SubTituloProperty_Changed
            );

        public string SubTitulo
        {
            get { return GetValue(SubTituloProperty).ToString(); }
            set { SetValue(SubTituloProperty, value); }
        }

        private static void SubTituloProperty_Changed(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = bindable as CustomCardView;
            myControl.subtitulo.Text = newValue.ToString();
        }

        public static readonly BindableProperty IconeProperty = BindableProperty.Create(
            propertyName: nameof(Icone),
            returnType: typeof(string),
            declaringType: typeof(CustomCardView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: IconeProperty_Changed
            );

        public string Icone
        {
            get { return GetValue(IconeProperty).ToString(); }
            set { SetValue(IconeProperty, value); }
        }

        private static void IconeProperty_Changed(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = bindable as CustomCardView;
            myControl.icone.Source = ImageSource.FromFile(newValue.ToString());
        }
    }
}