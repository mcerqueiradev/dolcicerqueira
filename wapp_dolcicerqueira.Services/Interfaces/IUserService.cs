using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IUserService
    {
        Users GetById(int id);
        List<Users> GetAll();
        //Users Update(Users user);
        List<Users> GetUserList(int id);
        Users GetUserLogin(string email, string password);
        Users Save(Users user);
        Users Update(Users user);
        void Delete(int id);
    }
}
