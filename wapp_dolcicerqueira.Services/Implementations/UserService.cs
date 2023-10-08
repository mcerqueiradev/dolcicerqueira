using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Users GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public Users GetUserLogin(string email, string password)
        {
            return _userRepository.GetUserLogin(email, password);
        }

        public List<Users> GetUserList(int id)
        {
            return _userRepository.GetUserList(id);
        }

        public List<Users> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Users Save(Users user)
        {
            if (user.Id > 0)
                return _userRepository.Update(user);
            else
                return _userRepository.Add(user);
        }

        public Users Update(Users user)
        {
            return _userRepository.Update(user);
        }
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

    }
}