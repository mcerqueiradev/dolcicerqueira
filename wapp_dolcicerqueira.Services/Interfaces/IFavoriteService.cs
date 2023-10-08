using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IFavoriteService
    {
        Favorite GetById(int id);
        List<Favorite> GetAll();
        List<Favorite> GetFavoriteUser(int id);
        Favorite Save(Favorite favorite);
        Favorite Update(Favorite favorite);
        void Delete(int id);
    }
}
