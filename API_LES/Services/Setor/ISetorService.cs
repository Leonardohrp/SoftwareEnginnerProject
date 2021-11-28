using API_LES.Models.Setor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Setor
{
    public interface ISetorService
    {
        Task<Models.Setor.Setor> GetSetorById(int id);
        Task<IEnumerable<Models.Setor.Setor>> GetAllSetores();
        Task<bool> CreateSetor(CreateSetor createSetor);
        Task<bool> UpdateSetorById(UpdateSetor updateSetor, int codSetor);
        Task<bool> DeleteSetorById(int codSetor);
    }
}
