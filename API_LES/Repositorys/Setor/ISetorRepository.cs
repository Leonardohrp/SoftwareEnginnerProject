using API_LES.Models.Setor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.Setor
{
    public interface ISetorRepository
    {
        Task<int> CreateSetor(CreateSetor createSetor);
        Task<int> DeleteSetorById(int codSetor);
        Task<Models.Setor.Setor> GetSetorById(int codSetor);
        Task<int> UpdateSetorById(UpdateSetor updateUser, int codSetor);
    }
}
