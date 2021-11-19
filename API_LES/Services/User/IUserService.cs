using API_LES.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.User
{
    public interface IUserService
    {
        Task<Models.User.User> GetUserById(int id);

        Task<bool> CreateUser(CreateUser createUser);

        Task<bool> UpdateUserById(UpdateUser updateUser, int id);

        Task<bool> DeleteUserById(int id);
    }
}
