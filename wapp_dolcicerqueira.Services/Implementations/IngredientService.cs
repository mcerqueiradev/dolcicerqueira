using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Ingredient GetById(int Id)
        {
            return _ingredientRepository.GetById(Id);
        }

        public List<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient Save(Ingredient ingredient)
        {
            if (ingredient.Id > 0)
                return _ingredientRepository.Update(ingredient);
            else
                return _ingredientRepository.Add(ingredient);
        }

        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
        }
    }
}
