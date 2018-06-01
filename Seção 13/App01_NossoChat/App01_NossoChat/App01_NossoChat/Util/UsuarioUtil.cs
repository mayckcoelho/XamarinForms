using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using App01_NossoChat.Model;

namespace App01_NossoChat.Util
{
    public class UsuarioUtil
    {
        public static void SetUsuarioLogado(Usuario usuario)
        {
            if (usuario != null)
                App.Current.Properties.Add("LOGIN", JsonConvert.SerializeObject(usuario));
        }

        public static Usuario GetUsuarioLogado()
        {
            if (App.Current.Properties.ContainsKey("LOGIN"))
                return JsonConvert.DeserializeObject<Usuario>(App.Current.Properties["LOGIN"].ToString());

            return null;
        }
    }
}
