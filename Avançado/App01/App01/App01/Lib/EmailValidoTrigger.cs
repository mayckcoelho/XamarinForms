using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App01.Lib
{
    public class EmailValidoTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            if (sender.Text.IndexOf("@") >= 0)
            {
                sender.TextColor = Color.Green;
            }
            else
            {
                sender.TextColor = Color.Red;
            }
        }
    }
}
