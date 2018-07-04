using App_Atelie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using App_Atelie.Business;

namespace App_Atelie.ViewModel
{
    public class ListagemPedidoViewModel : General.BaseViewModel
    {
        public ObservableCollection<Pedido> ListaPedidos { get; set; }

        public ListagemPedidoViewModel()
        {
            InicializarBancoDados();

            var pedidoBusiness = new PedidoBusiness();
            var lista = new ObservableCollection<Pedido>(pedidoBusiness.ToList());
            ListaPedidos = lista;
        }

        private void InicializarBancoDados()
        {
            var clienteBusiness = new ClienteBusiness();
            var pedidoBusiness = new PedidoBusiness();

            Cliente cliente;
            Pedido pedido;

            // Mayck
            cliente = clienteBusiness.GetNewEntity();
            cliente.Nome = "Mayck";
            cliente.Telefone = "19987450020";
            clienteBusiness.AddEntity(cliente);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Calca;
            pedido.Valor = 15.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Blaser;
            pedido.Valor = 20.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Calca;
            pedido.Valor = 25.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Blaser;
            pedido.Valor = 30.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            // Carol
            cliente = clienteBusiness.GetNewEntity();
            cliente.Nome = "Caroline";
            cliente.Telefone = "19988695968";
            clienteBusiness.AddEntity(cliente);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Blusa;
            pedido.Valor = 35.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Saia;
            pedido.Valor = 40.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Vestido;
            pedido.Valor = 45.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);

            pedido = pedidoBusiness.GetNewEntity();
            pedido.IdCliente = cliente.Id;
            pedido.TipoRoupa = General.TipoRoupa.Calca;
            pedido.Valor = 50.00M;
            pedido.Busto = 15;
            pedido.Cintura = 20;
            pedido.Quadril = 25;
            pedido.Torax = 30;
            pedidoBusiness.AddEntity(pedido);
        }
    }
}
