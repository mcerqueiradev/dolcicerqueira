using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMeasureRepository _measureRepository;

        public DashboardService(IRecipeRepository recipeRepository, IUserRepository userRepository, IIngredientRepository ingredientRepository, ICategoryRepository categoryRepository, IRatingRepository ratingRepository, IMeasureRepository measureRepository)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _ingredientRepository = ingredientRepository;
            _categoryRepository = categoryRepository;
            _ratingRepository = ratingRepository;
            _measureRepository = measureRepository;
        }

        public Users GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<Users> GetUserList(int id)
        {
            return _userRepository.GetUserList(id);
        }

        public List<Users> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Recipe GetRecipe(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public List<Recipe> GetRecipes()
        {
            var recipes = _recipeRepository.GetAll();
            foreach (var recipe in recipes)
            {
                recipe.Author = _userRepository.GetById(recipe.AuthorId);
                recipe.Category = _categoryRepository.GetById(recipe.CategoryId);
                recipe.Ratings = _ratingRepository.GetByIdRecipe(recipe.Id);
            }
            return recipes;
        }
    }
}
