using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IRatingService
    {
        Rating GetById(int id);

        List<Rating> GetAll();
        List<Rating> GetByIdRecipe(int id);
        public int GetRatingAvg(List<Rating> ratings);
        Rating Save(Rating rating);
        void Delete(int id);
    }
}
