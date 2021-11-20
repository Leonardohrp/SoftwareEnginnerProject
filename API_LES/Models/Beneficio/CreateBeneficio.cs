using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Models.Beneficio
{
    public class CreateBeneficio
    {
        public string TpBeneficio { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
