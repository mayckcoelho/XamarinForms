using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace App01_NossoChat.Droid
{
    [Activity(Label = "App01_NossoChat", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionSend }, Categories = new[] {
    Intent.CategoryDefault,
    Intent.CategoryBrowsable }, DataMimeType = "text/plain")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var app = new App();

            if (!String.IsNullOrEmpty(Intent.GetStringExtra(Intent.ExtraText)))
            {
                string subject = Intent.GetStringExtra(Intent.ExtraText) ?? "subject not available";
                var uri = new Uri(subject.Split('?')[1].Trim());

                app.Properties.Add("Uri", uri);
            }
            LoadApplication(app);
        }
    }
}

