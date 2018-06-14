using System;
using System.Collections.Generic;
using System.Text;

namespace App_Atelie.Model
{
    public class Medida : EntityBase<int>
    {
        public float Torax { get; set; }
        public float Busto { get; set; }
        public float Cintura { get; set; }
        public float Quadril { get; set; }
    }
}
