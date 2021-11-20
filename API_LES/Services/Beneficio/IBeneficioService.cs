using API_LES.Models.Beneficio;
using API_LES.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Beneficio
{
    public interface IBeneficioService
    {
        Task<Models.Beneficio.Beneficio> GetBeneficioById(int codBeneficio);

        Task<bool> CreateBeneficio(CreateBeneficio createBeneficio);

        Task<bool> UpdateBeneficioById(UpdateBeneficio updateBeneficio, int codBeneficio);

        Task<bool> DeleteBeneficioById(int codBeneficio);
    }
}
