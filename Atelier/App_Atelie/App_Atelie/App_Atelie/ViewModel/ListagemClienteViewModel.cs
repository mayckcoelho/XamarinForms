using App_Atelie.Business;
using App_Atelie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App_Atelie.ViewModel
{
    public class ListagemClienteViewModel : General.BaseViewModel
    {
        public ObservableCollection<Cliente> ListaClientes { get; set; }

        public ListagemClienteViewModel()
        {
            var clienteBusiness = new ClienteBusiness();
            var lista = new ObservableCollection<Cliente>(clienteBusiness.ToList());
            ListaClientes = lista;
        }
    }
}
