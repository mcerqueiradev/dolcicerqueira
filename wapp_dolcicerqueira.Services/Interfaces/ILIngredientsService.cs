using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface ILIngredientsService
    {
        LIngredients Add();
        List<LIngredients> GetAll();
        List<LIngredients> GetByIdRecipe(int id);
        List<LIngredients> SelectIngredientByRecipe(int id);
        LIngredients Save(LIngredients lIngredients);
        void Delete(int id);
    }
}
