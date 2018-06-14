using App_Atelie.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Atelie.Model
{
    public class Pedido : EntityBase<int>
    {
        public virtual Cliente Cliente { get; set; }

        public virtual Medida Medida { get; set; }

        public int IdCliente { get; set; }

        public int IdMedida { get; set; }

        public decimal Valor { get; set; }

        public TipoRoupa TipoRoupa { get; set; }

        public string Foto { get; set; }

        public DateTime DataEntrega { get; set; }
    }
}
