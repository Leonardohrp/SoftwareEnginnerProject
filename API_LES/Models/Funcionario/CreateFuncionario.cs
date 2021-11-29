using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Models.Funcionario
{
    public class CreateFuncionario
    {
        public string Nome { get; set; }
        public string NrDoc { get; set; }
        public string Endereco { get; set; }
        public string EstadoCivil { get; set; }
        public int CodCargo { get; set; }
        public float Salario { get; set; }
        public DateTime DtContratacao { get; set; }
    }
}
