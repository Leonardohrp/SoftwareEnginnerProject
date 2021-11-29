using API_LES.Data;
using API_LES.Models.Setor;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.Setor
{
    public class SetorRepository : ISetorRepository
    {
        private readonly IDataContext _dataContext;
        public SetorRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateSetor(CreateSetor createSetor)
        {
            var connectionString = _dataContext.GetConnection();

            int isSetorCreated = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"INSERT INTO Setor (   [NomeSetor],
                                                        [Ramal]
                                                    ) 
                                             VALUES (
                                                        @NomeSetor,
                                                        @Ramal
                                                    );";
                    isSetorCreated = await connnection.ExecuteAsync(query,
                            new
                            {
                                NomeSetor = createSetor.NomeSetor,
                                Ramal = createSetor.Ramal,
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
                return isSetorCreated;
            }
        }

        public async Task<int> DeleteSetorById(int codSetor)
        {
            var connectionString = _dataContext.GetConnection();

            int isSetorDeleted = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "DELETE FROM Setor WHERE CodSetor = @CodSetor";
                    isSetorDeleted = await connnection.ExecuteAsync(query, new { CodSetor = codSetor });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isSetorDeleted;
            }
        }

        public async Task<Models.Setor.Setor> GetSetorById(int codSetor)
        {
            var connectionString = _dataContext.GetConnection();

            Models.Setor.Setor setor = new Models.Setor.Setor();
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Setor WHERE CodSetor = @CodSetor";
                    setor = await connnection.QueryFirstOrDefaultAsync<Models.Setor.Setor>(query, new { CodSetor = codSetor });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return setor;
            }
        }
        
         public async Task<IEnumerable<Models.Setor.Setor>> GetAllSetores()
        {
            var connectionString = _dataContext.GetConnection();

            IEnumerable<Models.Setor.Setor> setores = new List<Models.Setor.Setor>();
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Setor";
                    setores = await connnection.QueryAsync<Models.Setor.Setor>(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return setores;
            }
        }

        public async Task<int> UpdateSetorById(UpdateSetor updateUser, int codSetor)
        {
            var connectionString = _dataContext.GetConnection();

            int isSetorUpdated = 0;

            Models.Setor.Setor setor = await GetSetorById(codSetor);

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"UPDATE Setor SET  
                                            [NomeSetor] = @NomeSetor,
                                            [Ramal] = @Ramal
                                                WHERE CodSetor = @CodSetor";
                    isSetorUpdated = await connnection.ExecuteAsync(query,
                            new
                            {
                                NomeSetor = updateUser.NomeSetor,
                                Ramal = updateUser.Ramal,
                                CodSetor = codSetor
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
                return isSetorUpdated;
            }
        }
    }
}
