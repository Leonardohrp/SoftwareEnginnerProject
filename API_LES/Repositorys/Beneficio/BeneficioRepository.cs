using API_LES.Data;
using API_LES.Models.Beneficio;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.Beneficio
{
    public class BeneficioRepository : IBeneficioRepository
    {
        private readonly IDataContext _dataContext;
        public BeneficioRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateBeneficio(CreateBeneficio createBeneficio)
        {
            var connectionString = _dataContext.GetConnection();

            int isBeneficioCreated = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"INSERT INTO Beneficio (   [TpBeneficio],
                                                            [Nome],
                                                            [Valor]
                                                        ) 
                                                 VALUES (
                                                            @TpBeneficio,
                                                            @Nome,
                                                            @Valor
                                                        );";
                    isBeneficioCreated = await connnection.ExecuteAsync(query,
                            new
                            {
                                TpBeneficio = createBeneficio.TpBeneficio,
                                Nome = createBeneficio.Nome,
                                Valor = createBeneficio.Valor
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
                return isBeneficioCreated;
            }
        }

        public async Task<int> DeleteBeneficioById(int codBeneficio)
        {
            var connectionString = _dataContext.GetConnection();

            int isBeneficioDeleted = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "DELETE FROM Beneficio WHERE CodBeneficio = @codBeneficio";
                    isBeneficioDeleted = await connnection.ExecuteAsync(query, new { CodBeneficio = codBeneficio });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isBeneficioDeleted;
            }
        }

        public async Task<Models.Beneficio.Beneficio> GetBeneficioById(int codBeneficio)
        {
            var connectionString = _dataContext.GetConnection();

            Models.Beneficio.Beneficio user = new Models.Beneficio.Beneficio();
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Beneficio WHERE CodBeneficio = @CodBeneficio";
                    user = await connnection.QueryFirstOrDefaultAsync<Models.Beneficio.Beneficio>(query, new { CodBeneficio = codBeneficio });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return user;
            }
        }

        public async Task<int> UpdateBeneficioById(UpdateBeneficio updateBeneficio, int codBeneficio)
        {
            var connectionString = _dataContext.GetConnection();

            int isBeneficioUpdated = 0;

            Models.Beneficio.Beneficio beneficio = await GetBeneficioById(codBeneficio);

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"UPDATE Beneficio SET  
                                            [TpBeneficio] = @TpBeneficio,
                                            [Nome] = @Nome,
                                            [Valor] = @Valor
                                                WHERE CodBeneficio = @CodBeneficio";
                    isBeneficioUpdated = await connnection.ExecuteAsync(query,
                            new
                            {
                                TpBeneficio = string.IsNullOrEmpty(updateBeneficio.TpBeneficio) ? beneficio.TpBeneficio : updateBeneficio.TpBeneficio,
                                Nome = string.IsNullOrEmpty(updateBeneficio.Nome) ? beneficio.Nome : updateBeneficio.Nome,
                                Valor = string.IsNullOrEmpty(updateBeneficio.Valor.ToString()) ? beneficio.Valor : updateBeneficio.Valor,
                                CodBeneficio = codBeneficio
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
                return isBeneficioUpdated;
            }
        }
    }
}
