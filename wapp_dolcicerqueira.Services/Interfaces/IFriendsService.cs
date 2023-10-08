using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IFriendsService
    {
        Friends GetById(int id);
        List<Friends> GetAll();
        List<Friends> GetFriendsByUserId(int id);

        List<Friends> GetFriendRequest(int id);
        Friends GetFriendByUserIds(int userOne, int userTwo);
        Friends Save(Friends friends);
        Friends Update(Friends friends);
        void Delete(int id);
    }
}
