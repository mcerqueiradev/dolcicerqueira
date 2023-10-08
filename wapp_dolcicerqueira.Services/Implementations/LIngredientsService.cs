using System;
using System.Collections.Generic;
using System.Linq;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Implementations;
using wapp_dolcicerqueira.Repositories.Interfaces;
using wapp_dolcicerqueira.Repositories.Repositories.Interfaces;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class LIngredientsService : ILIngredientsService
    {
        private readonly ILIngredientsRepository _lingredientsRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMeasureRepository _measureRepository;


        public LIngredientsService(ILIngredientsRepository lIngredientsRepository, IIngredientRepository ingredientRepository, IMeasureRepository measureRepository)
        {
            _lingredientsRepository = lIngredientsRepository;
            _ingredientRepository = ingredientRepository;
            _measureRepository = measureRepository;
        }

        public LIngredients Add()
        {
            LIngredients lIngredientsList = new LIngredients();
            lIngredientsList.Ingredients = _ingredientRepository.GetAll();
            lIngredientsList.Measures = _measureRepository.GetAll();
            return lIngredientsList;
        }

        public List<LIngredients> GetAll()
        {
            return _lingredientsRepository.GetAll();
        }

        public List<LIngredients> GetByIdRecipe(int id)
        {
            return _lingredientsRepository.GetByIdRecipe(id);
        }

        public List<LIngredients> SelectIngredientByRecipe(int id)
        {
            return _lingredientsRepository.SelectIngredientsByRecipe(id);
        }

        public LIngredients Save(LIngredients lIngredients)
        {
            if (lIngredients.Id > 0)
                return _lingredientsRepository.Update(lIngredients);
            else
                return _lingredientsRepository.Add(lIngredients);
        }

        public void Delete(int Id)
        {
            _lingredientsRepository.Delete(Id);
        }
    }
}
