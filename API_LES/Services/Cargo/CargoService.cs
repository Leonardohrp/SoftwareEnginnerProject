using API_LES.Models.Cargo;
using API_LES.Repositorys.Cargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.Cargo
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _repo;
        public CargoService(ICargoRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateCargo(CreateCargo createCargo)
        {
            if (await _repo.CreateCargo(createCargo) != 1)
                throw new Exception("Criação de Cargo falhou.");

            return true;
        }

        public async Task<bool> DeleteCargoById(int codCargo)
        {
            if (await _repo.DeleteCargoById(codCargo) != 1)
                throw new Exception("Exclusão de Cargo falhou.");

            return true;
        }

        public async Task<Models.Cargo.Cargo> GetCargoById(int codCargo)
        {
            var cargo = await _repo.GetCargoById(codCargo);

            if (cargo == null)
                throw new Exception("Cargo não cadastrado.");

            return cargo;
        }

        public async Task<bool> UpdateCargoById(UpdateCargo updateCargo, int codCargo)
        {
            if (string.IsNullOrEmpty(codCargo.ToString()))
                throw new Exception("CodCargo do Cargo vazio ou nulo.");

            var cargoUpdated = await _repo.UpdateCargoById(updateCargo, codCargo);

            if (cargoUpdated == 0)
                throw new Exception("Atualização do Cargo falhou.");

            return true;
        }
    }
}
