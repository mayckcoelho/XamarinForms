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

[assembly: Xamarin.Forms.Dependency(typeof(App02_SOAPClient.Droid.Service.ServiceSOAP))]
namespace App02_SOAPClient.Droid.Service
{
    public class ServiceSOAP : IServiceSOAP
    {
        public string Somar(int num1, int num2)
        {
            int resultado = new com.dneonline.www.Calculator().Add(num1, num2);
            return "Resultado WS SOAP: " + (resultado).ToString();
        }
    }
}