using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Recipe GetById(int id);
        List<Recipe> GetAll();
        List<Recipe> RecipesApproved();
        List<Recipe> RecipesApprovedById();
        List<Recipe> RecipesUnapproved();
        Recipe Add(Recipe recipe);
        Recipe LastRecipe();
        Recipe Update(Recipe recipe);
        void Delete(int id);
    }
}
