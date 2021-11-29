
using API_LES.Models.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        public Task<bool> CreateFuncionario(CreateFuncionario createFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFuncionarioById(int codFunc)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Funcionario.Funcionario> GetFuncionarioById(int codFunc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFuncionarioById(UpdateFuncionario updatefuncionario, int codFunc)
        {
            throw new NotImplementedException();
        }
    }
}
