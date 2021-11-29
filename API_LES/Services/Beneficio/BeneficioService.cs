using API_LES.Helpers;
using API_LES.Models.Beneficio;
using API_LES.Repositorys.Beneficio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Beneficio
{
    public class BeneficioService : IBeneficioService
    {
        private readonly IBeneficioRepository _repo;
        public BeneficioService(IBeneficioRepository repo)
        {
            _repo = repo;
        }        

        public async Task<bool> CreateBeneficio(CreateBeneficio createBeneficio)
        {
            // Todo -> ObjectValiadtion.IsAnyNullOrEmpty(object) 
            // Mudar a função para que ela pegue um dicionário e retorne uma exceção do campo e se esta vázio num lista na exceção

            if (await _repo.CreateBeneficio(createBeneficio) != 1)
                throw new Exception("Criação de benefício falhou.");
            
            return true;
        }

        public async Task<bool> DeleteBeneficioById(int codBeneficio)
        {
            // Todo -> verificar se existe o id cadastrado antes
            if (await _repo.DeleteBeneficioById(codBeneficio) != 1)
                throw new Exception("Exclusão de benefício falhou.");

            return true;
        }

        public async Task<IEnumerable<Models.Beneficio.Beneficio>> GetAllBeneficios()
        {
            var beneficio = await _repo.GetAllBeneficios();

            if (beneficio == null)
            {
                throw new Exception("Nenhum benefício cadastrado.");
            }

            return beneficio;
        }

        public async Task<Models.Beneficio.Beneficio> GetBeneficioById(int codBeneficio)
        {
            var beneficio = await _repo.GetBeneficioById(codBeneficio);

            if (beneficio == null)
            {
                throw new Exception("Benefício não cadastrado.");
            }

            return beneficio;
        }

        public async Task<bool> UpdateBeneficioById(UpdateBeneficio updateBeneficio, int codBeneficio)
        {
            if (string.IsNullOrEmpty(codBeneficio.ToString()))
                throw new Exception("CodBeneficio do Beneficio vazio ou nulo.");

            var beneficioUpdated = await _repo.UpdateBeneficioById(updateBeneficio, codBeneficio);

            if (beneficioUpdated == 0)
                throw new Exception("Atualização do benefício falhou.");

            return true;
        }
    }
}
