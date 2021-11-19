using API_LES.Models.User;
using API_LES.Repositorys.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateUser(CreateUser createUser)
        {
            string login = createUser.FirstName + "_" + createUser.LastName;

            if (await _repo.CreateUser(createUser, login) != 1)
                throw new Exception("Criação de usuário falhou.");

            return true;
        }

        public async Task<bool> DeleteUserById(int id)
        {
           if(await _repo.DeleteUserById(id) != 1)
                throw new Exception("Exclusão de usuário falhou.");

            return true;
        }

        public async Task<Models.User.User> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            
            if(user == null)
            {
                throw new Exception("Usuário não cadastrado.");
            }

            return user;
        }

        public async Task<bool> UpdateUserById(UpdateUser updateUser, int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                throw new Exception("Id do usuário vazio ou nulo.");
            
            string login = updateUser.FirstName + "_" + updateUser.LastName;

            var userUpdated = await _repo.UpdateUserById(updateUser, id, login);

            if(userUpdated == 0)
                throw new Exception("Atualização do usuário falhou.");

            return true;
        }
    }
}
