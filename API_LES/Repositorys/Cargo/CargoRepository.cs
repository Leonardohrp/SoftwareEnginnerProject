using API_LES.Data;
using API_LES.Models.Cargo;
using System;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace API_LES.Repositorys.Cargo
{
    public class CargoRepository : ICargoRepository
    {
        private readonly IDataContext _dataContext;
        public CargoRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateCargo(CreateCargo createCargo)
        {
            var connectionString = _dataContext.GetConnection();

            int isCargoCreated = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"INSERT INTO Cargo (   [NomeCargo],
                                                        [PisoSalarial]
                                                    ) 
                                            VALUES 
                                                    (
                                                        @NomeCargo,
                                                        @PisoSalarial
                                                    );";
                    isCargoCreated = await connnection.ExecuteAsync(query,
                            new
                            {
                                NomeCargo = createCargo.NomeCargo,
                                PisoSalarial = createCargo.PisoSalarial,
                            });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isCargoCreated;
            }
        }

        public async Task<int> DeleteCargoById(int codCargo)
        {
            var connectionString = _dataContext.GetConnection();

            int isCargoDeleted = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "DELETE FROM Cargo WHERE CodCargo = @CodCargo";
                    isCargoDeleted = await connnection.ExecuteAsync(query, new { CodCargo = codCargo });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isCargoDeleted;
            }
        }

        public async Task<Models.Cargo.Cargo> GetCargoById(int codCargo)
        {
            var connectionString = _dataContext.GetConnection();

            Models.Cargo.Cargo cargo = new Models.Cargo.Cargo();
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Cargo WHERE CodCargo = @CodCargo";
                    cargo = await connnection.QueryFirstOrDefaultAsync<Models.Cargo.Cargo>(query, new { CodCargo = codCargo });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return cargo;
            }
        }

        public async Task<int> UpdateCargoById(UpdateCargo updateCargo, int codCargo)
        {
            var connectionString = _dataContext.GetConnection();

            int isCargoUpdated = 0;

            Models.Cargo.Cargo cargo = await GetCargoById(codCargo);

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"UPDATE Cargo SET  
                                            [NomeCargo] = @NomeCargo,
                                            [PisoSalarial] = @PisoSalarial
                                                WHERE CodCargo = @CodCargo";
                    isCargoUpdated = await connnection.ExecuteAsync(query,
                            new
                            {
                                NomeCargo = string.IsNullOrEmpty(updateCargo.NomeCargo) ? cargo.NomeCargo : updateCargo.NomeCargo,
                                PisoSalarial = string.IsNullOrEmpty(updateCargo.PisoSalarial.ToString()) ? cargo.PisoSalarial : updateCargo.PisoSalarial,
                                CodCargo = codCargo
                            });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isCargoUpdated;
            }
        }
    }
}
