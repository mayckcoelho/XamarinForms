using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(App02_SOAPClient.iOS.Service.ServiceSOAP))]
namespace App02_SOAPClient.iOS.Service
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