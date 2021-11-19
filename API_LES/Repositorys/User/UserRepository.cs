using API_LES.Data;
using API_LES.Models;
using API_LES.Models.User;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _dataContext;
        public UserRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateUser(CreateUser createUser, string login)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserCreated = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"INSERT INTO Users (   [FirstName],
                                                        [LastName],
                                                        [email],
                                                        [login],
                                                        [Password]
                                                    ) 
                                             VALUES (
                                                        @FirstName,
                                                        @LastName,
                                                        @email,
                                                        @login,
                                                        @Password
                                                    );";
                    isUserCreated = await connnection.ExecuteAsync(query, 
                            new { 
                                    FirstName = createUser.FirstName, 
                                    LastName = createUser.LastName,
                                    email = createUser.email, 
                                    login = login, 
                                    Password = createUser.Password
                                } );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {   
                    connnection.Close();
                }
                return isUserCreated;
            }
        }

        public async Task<int> DeleteUserById(int id)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserDeleted = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "DELETE FROM Users WHERE IdUser = @Id";
                    isUserDeleted = await connnection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isUserDeleted;
            }
        }

        public async Task<Models.User.User> GetUserById(int id)
        {
            var connectionString = _dataContext.GetConnection();

            Models.User.User user = new Models.User.User();
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Users WHERE IdUser = @Id";
                    user = await connnection.QueryFirstOrDefaultAsync<Models.User.User>(query, new { Id = id } );
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

        public async Task<int> UpdateUserById(UpdateUser updateUser, int id, string login)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserUpdated = 0;

            Models.User.User user = await GetUserById(id);

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"UPDATE Users SET  
                                            [FirstName] = @FirstName,
                                            [LastName] = @LastName,
                                            [email] = @email,
                                            [login] = @login,
                                            [Password] = @Password
                                                WHERE IdUser = @Id";
                    isUserUpdated = await connnection.ExecuteAsync(query,
                            new
                            {
                                FirstName = string.IsNullOrEmpty(updateUser.FirstName) ? user.FirstName : updateUser.FirstName,
                                LastName = string.IsNullOrEmpty(updateUser.LastName) ? user.LastName : updateUser.LastName,
                                email = string.IsNullOrEmpty(updateUser.email) ? user.email : updateUser.email,
                                login = login,
                                Password = string.IsNullOrEmpty(updateUser.Password) ? user.Password : updateUser.Password,
                                Id = id
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
                return isUserUpdated;
            }
        }
    }
}
