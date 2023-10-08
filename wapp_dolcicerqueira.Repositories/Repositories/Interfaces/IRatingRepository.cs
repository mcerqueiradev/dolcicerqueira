using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Rating GetById(int id);
        Rating Add(Rating rating);
        List<Rating> GetByIdRecipe(int id);

        List<Rating> GetAll();
        Rating Update(Rating rating);
        void Delete(int id);
    }
}
