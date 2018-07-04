using App_Atelie.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_Atelie.Business
{
    public class PedidoBusiness : BusinessBase<Pedido, int>
    {
        public override List<Pedido> ToList()
        {
            return _repository.GetQuery()
                .Include(p => p.Cliente)
                .ToList();
        }
    }
}
