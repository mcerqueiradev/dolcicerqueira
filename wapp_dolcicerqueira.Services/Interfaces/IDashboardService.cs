using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IDashboardService
    {
        Users GetById(int id);
        List<Users> GetAll();
        List<Users> GetUserList(int id);
        Recipe GetRecipe(int id);
        List<Recipe> GetRecipes();
    }
}
