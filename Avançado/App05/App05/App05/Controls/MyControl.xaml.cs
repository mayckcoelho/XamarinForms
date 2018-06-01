using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyControl : ContentView
	{
        #region Tapped
        public event EventHandler Tapped;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Tapped?.Invoke(sender, e);
        }
        #endregion

        #region Titulo
        public static readonly BindableProperty TituloProperty = BindableProperty.Create(
            propertyName: nameof(Titulo),
            returnType: typeof(string),
            declaringType: typeof(MyControl),
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
            var myControl = bindable as MyControl;
            myControl.titulo.Text = newValue.ToString();
        }
        #endregion

        #region TituloCor
        public static readonly BindableProperty TituloCorProperty = BindableProperty.Create(
            propertyName: nameof(TituloCor),
            returnType: typeof(Color),
            declaringType: typeof(MyControl),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TituloCorProperty_Changed
            );

        public Color TituloCor
        {
            get { return (Color)GetValue(TituloCorProperty); }
            set { SetValue(TituloCorProperty, value); }
        }

        private static void TituloCorProperty_Changed(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = bindable as MyControl;
            myControl.titulo.TextColor = (Color)newValue;
        }
        #endregion

        #region Imagem
        public static readonly BindableProperty ImagemProperty = BindableProperty.Create(
            propertyName: nameof(Imagem),
            returnType: typeof(string),
            declaringType: typeof(MyControl),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ImagemProperty_Changed
            );

        public string Imagem
        {
            get { return GetValue(ImagemProperty).ToString(); }
            set { SetValue(ImagemProperty, value); }
        }

        private static void ImagemProperty_Changed(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = bindable as MyControl;
            myControl.imagem.Source = ImageSource.FromFile(newValue.ToString());
        }
        #endregion

        public MyControl ()
		{
			InitializeComponent ();
		}
    }
}