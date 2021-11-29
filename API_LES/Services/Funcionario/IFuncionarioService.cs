using API_LES.Models.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Funcionario
{
    public interface IFuncionarioService
    {
        Task<bool> DeleteFuncionarioById(int codFunc);
        Task<bool> UpdateFuncionarioById(UpdateFuncionario updatefuncionario, int codFunc);
        Task<bool> CreateFuncionario(CreateFuncionario createFuncionario);
        Task<Models.Funcionario.Funcionario> GetFuncionarioById(int codFunc);
    }
}
