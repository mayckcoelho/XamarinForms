using App_Atelie.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Atelie.Model
{
    public class Pedido : EntityBase<int>
    {
        public virtual Cliente Cliente { get; set; }

        public int IdCliente { get; set; }

        public decimal Valor { get; set; }

        public TipoRoupa TipoRoupa { get; set; }

        public string Foto { get; set; }

        public DateTime DataEntrega { get; set; }

        #region Medidas
        public float? Torax { get; set; }

        public float? Busto { get; set; }

        public float? Cintura { get; set; }

        public float? Quadril { get; set; }

        public float? LarguraCosta { get; set; }

        public float? SeparacaoBusto { get; set; }

        public float? AlturaBusto { get; set; }

        public float? AlturaFrenteBlusa { get; set; }

        public float? AlturaCava { get; set; }

        public float? Ombro { get; set; }

        public float? LarguraBraco { get; set; }

        public float? LarguraPunho { get; set; }

        public float? AlturaMangaLonga { get; set; }

        public float? AlturaMangaCurta { get; set; }

        public float? AlturaQuadril { get; set; }

        public float? AlturaGancho { get; set; }

        public float? AlturaJoelho { get; set; }

        public float? LarguraJoelho { get; set; }

        public float? AlturaTornozelo { get; set; }

        public float? LarguraTornozelo { get; set; }
        #endregion
    }
}
