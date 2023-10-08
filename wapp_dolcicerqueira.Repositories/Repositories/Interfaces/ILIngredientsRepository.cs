using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;

namespace wapp_dolcicerqueira.Repositories.Repositories.Interfaces
{
    public interface ILIngredientsRepository
    {
        LIngredients Add(LIngredients lIngredients);
        List<LIngredients> GetAll();
        List<LIngredients> GetByIdRecipe(int id);

        List<LIngredients> SelectIngredientsByRecipe(int id);
        LIngredients Update(LIngredients lIngredients);
        void Delete(int id);
    }
}
