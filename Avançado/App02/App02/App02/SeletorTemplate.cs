using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App02
{
    public class SeletorTemplate : DataTemplateSelector
    {
        DataTemplate ItemPessoaObrigatoria;
        DataTemplate ItemPessoaNaoObrigatoria;

        public SeletorTemplate()
        {
            ItemPessoaObrigatoria = new DataTemplate(typeof(Templates.ItemPessoaObrigatoriaViewCell));
            ItemPessoaNaoObrigatoria = new DataTemplate(typeof(Templates.ItemPessoaNaoObrigatoriaViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var pessoa = item as MainPage.Funcionario;

            if (pessoa.IsObrigatorio)
                return ItemPessoaObrigatoria;
            else
                return ItemPessoaNaoObrigatoria;
        }
    }
}
