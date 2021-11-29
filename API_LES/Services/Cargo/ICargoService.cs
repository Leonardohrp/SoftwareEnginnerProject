using API_LES.Models.Cargo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_LES.Services.Cargo
{
    public interface ICargoService
    {
        Task<Models.Cargo.Cargo> GetCargoById(int codCargo);
        Task<IEnumerable<Models.Cargo.Cargo>> GetAllCargos();
        Task<bool> CreateCargo(CreateCargo createCargo);
        Task<bool> UpdateCargoById(UpdateCargo updateCargo, int codCargo);
        Task<bool> DeleteCargoById(int codCargo);
    }
}
