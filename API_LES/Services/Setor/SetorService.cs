using API_LES.Models.Setor;
using API_LES.Repositorys.Setor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Setor
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _repo;

        public SetorService(ISetorRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateSetor(CreateSetor createSetor)
        {
            if (await _repo.CreateSetor(createSetor) != 1)
                throw new Exception("Criação de setor falhou.");

            return true;
        }

        public async Task<bool> DeleteSetorById(int codSetor)
        {
           if(await _repo.DeleteSetorById(codSetor) != 1)
                throw new Exception("Exclusão de usuário falhou.");

            return true;
        }

        public async Task<Models.Setor.Setor> GetSetorById(int id)
        {
            var setor = await _repo.GetSetorById(id);

            if (setor == null)
                throw new Exception("Setor não cadastrado.");

            return setor;
        }

        public async Task<IEnumerable<Models.Setor.Setor>> GetAllSetores()
        {
            var setores = await _repo.GetAllSetores();

            if (setores == null)
                throw new Exception("Nenhum setor cadastrado.");

            return setores;
        }

        public async Task<bool> UpdateSetorById(UpdateSetor updateSetor, int codSetor)
        {
            if (string.IsNullOrEmpty(codSetor.ToString()))
                throw new Exception("Id do setor vazio ou nulo.");

            var setorUpdated = await _repo.UpdateSetorById(updateSetor, codSetor);

            if (setorUpdated == 0)
                throw new Exception("Atualização do setor falhou.");

            return true;
        }
    }
}
