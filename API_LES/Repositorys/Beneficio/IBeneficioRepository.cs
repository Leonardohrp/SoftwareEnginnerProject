using API_LES.Models.Beneficio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.Beneficio
{
    public interface IBeneficioRepository
    {
        Task<Models.Beneficio.Beneficio> GetBeneficioById(int codBeneficio);
        Task<int> CreateBeneficio(CreateBeneficio createBeneficio);
        Task<int> UpdateBeneficioById(UpdateBeneficio updateBeneficio, int codBeneficio);
        Task<int> DeleteBeneficioById(int codBeneficio);
    }
}
