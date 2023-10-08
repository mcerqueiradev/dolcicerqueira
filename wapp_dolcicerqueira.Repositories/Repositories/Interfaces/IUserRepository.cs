using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Users GetById(int id);
        Users GetUserLogin(string email, string password);
        List<Users> GetAll();
        List<Users> GetUserList(int id);
        Users Add(Users user);
        Users Update(Users user);
        void Delete(int id);
    }
}
