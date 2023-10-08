using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Ingredient GetById(int id);
        List<Ingredient> GetAll();
        Ingredient Add(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
    }
}
