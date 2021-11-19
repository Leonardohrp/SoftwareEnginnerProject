using API_LES.Models;
using API_LES.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Repositorys.User
{
    public interface IUserRepository
    {
        Task<Models.User.User> GetUserById(int id);
        Task<int> CreateUser(CreateUser createUser, string login);
        Task<int> UpdateUserById(UpdateUser updateUser, int id, string login);
        Task<int> DeleteUserById(int id);
    }
}
