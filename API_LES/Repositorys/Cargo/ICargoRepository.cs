using API_LES.Models.Cargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.Cargo
{
    public interface ICargoRepository
    {
        Task<Models.Cargo.Cargo> GetCargoById(int codCargo);
        Task<int> CreateCargo(CreateCargo createCargo);
        Task<int> UpdateCargoById(UpdateCargo updateCargo, int codCargo);
        Task<int> DeleteCargoById(int codCargo);
    }
}

