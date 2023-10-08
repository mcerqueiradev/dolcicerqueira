using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly IUserRepository _userRepository;

        public FriendsService(IUserRepository userRepository, IFriendsRepository friendsRepository)
        {
            _userRepository = userRepository;
            _friendsRepository = friendsRepository;
        }

        public Friends GetById(int id)
        {        
            return _friendsRepository.GetById(id);
        }

        public List<Friends> GetFriendsByUserId(int id)
        {
            return _friendsRepository.GetFriendsByUserId(id);
        }

        public Friends GetFriendByUserIds(int userOneId, int userTwoId)
        {
            Friends friend = _friendsRepository.GetFriendByUserIds(userOneId, userTwoId);

            if (friend == null)
            {
                // Se não houver registro na base de dados, significa que não são amigos
                return null;
            }
            else if (friend.Status == false)
            {
                // Se o status de amizade for falso, significa que há um pedido de amizade pendente
                return friend;
            }
            else
            {
                // Se o status de amizade for verdadeiro, significa que são amigos
                return friend;
            }
        }

            public List<Friends> GetAll()
        {
            return _friendsRepository.GetAll();
        }

        public Friends Save(Friends friends)
        {
            if (friends.Id > 0)
                return _friendsRepository.Update(friends);
            else
                return _friendsRepository.Add(friends);
        }

        public Friends Update(Friends friends)
        {
            return _friendsRepository.Update(friends);
        }
        public void Delete(int id)
        {
            _friendsRepository.Delete(id);
        }

        public List<Friends> GetFriendRequest(int id)
        {
            return _friendsRepository.GetFriendsByUserId(id);
        }
    }
}
