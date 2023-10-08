using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IRecipeService
    {
        Recipe GetById(int id);
        Recipe AddRecipe(Recipe recipe);
        List<Recipe> GetAll();
        IEnumerable<Recipe> Search(string searchTerm);

        IEnumerable<Recipe> GetByCategory(string category);

        List<Recipe> RecipesApproved();

        List<Recipe> RecipesApprovedById();
        List<Recipe> RecipesUnapproved();

        Recipe LastRecipe();
        Recipe Save(Recipe recipe);
        void Delete(int id);
    }
}
