using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IIngredientService
    {
        Ingredient GetById(int id);
        List<Ingredient> GetAll();
        Ingredient Save(Ingredient ingredient);
        void Delete(int id);
    }
}
