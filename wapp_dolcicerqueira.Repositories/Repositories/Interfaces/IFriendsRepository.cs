using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IFriendsRepository
    {
        Friends GetById(int id);
        List<Friends> GetAll();
        List<Friends> GetFriendsByUserId(int id);

        Friends GetFriendByUserIds(int userOne, int userTwo);
        Friends Add(Friends friends);
        Friends Update(Friends friends);
        void Delete(int id);
    }
}
