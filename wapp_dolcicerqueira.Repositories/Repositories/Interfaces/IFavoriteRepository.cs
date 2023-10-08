using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        Favorite GetById(int id);
        List<Favorite> GetAll();
        List<Favorite> GetFavoriteUser(int id);
        Favorite Add(Favorite favorite);
        Favorite Update(Favorite favorite);
        void Delete(int id);
    }
}
