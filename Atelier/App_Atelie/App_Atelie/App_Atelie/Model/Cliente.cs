using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App_Atelie.Model
{
    public class Cliente : EntityBase<int>
    {
        public Cliente()
        {
            this.Pedidos = new HashSet<Pedido>(); 
        }

        public virtual Medida MedidaPadrao { get; set; }

        public int IdMedidaPadrao { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public virtual HashSet<Pedido> Pedidos { get; set; }
    }
}
