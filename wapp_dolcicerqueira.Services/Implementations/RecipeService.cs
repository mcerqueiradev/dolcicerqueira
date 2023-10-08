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
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILIngredientsRepository _lingredientsRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMeasureRepository _measureRepository;

        public RecipeService(IRecipeRepository recipeRepository, IUserRepository userRepository, ILIngredientsRepository lingredientsRepository, IIngredientRepository ingredientRepository, ICategoryRepository categoryRepository, IRatingRepository ratingRepository, IMeasureRepository measureRepository)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _lingredientsRepository = lingredientsRepository;
            _ingredientRepository = ingredientRepository;
            _categoryRepository = categoryRepository;
            _ratingRepository = ratingRepository;
            _measureRepository = measureRepository;
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
            return recipe;
        }

        public List<Recipe> GetAll()
        {
            var recipes = _recipeRepository.GetAll();
            foreach (var recipe in recipes)
            {
                recipe.Author = _userRepository.GetById(recipe.AuthorId);
                recipe.Category = _categoryRepository.GetById(recipe.CategoryId);
                recipe.Ratings = _ratingRepository.GetByIdRecipe(recipe.Id);
                recipe.ListIngredients = _lingredientsRepository.GetByIdRecipe(recipe.Id);
            }
            return recipes;
        }

        public Recipe GetById(int Id)
        {
            Recipe recipe = _recipeRepository.GetById(Id);
            recipe.Author = _userRepository.GetById(recipe.AuthorId);
            recipe.Category = _categoryRepository.GetById(recipe.CategoryId);
            recipe.Ratings = _ratingRepository.GetByIdRecipe(recipe.Id);
            recipe.ListIngredients = _lingredientsRepository.GetByIdRecipe(recipe.Id);
            foreach (var recipeListIngredients in recipe.ListIngredients)
            {
                recipeListIngredients.Ingredient = _ingredientRepository.GetById(recipeListIngredients.IngredientId);
                recipeListIngredients.Measure = _measureRepository.GetById(recipeListIngredients.MeasureId);
            }
            return recipe;
        }

        public IEnumerable<Recipe> GetByCategory(string category)
        {
            return _recipeRepository.GetAll()
                .Where(r => r.Category.Name == category)
                .ToList();
        }

        public IEnumerable<Recipe> Search(string searchTerm)
        {
            return _recipeRepository.GetAll()
                .Where(r => r.Title.Contains(searchTerm) || r.Description.Contains(searchTerm))
                .ToList();
        }

        public List<Recipe> RecipesApproved()
        {
            var recipes = _recipeRepository.RecipesApproved();
            foreach (var recipe in recipes)
            {
                recipe.Author = _userRepository.GetById(recipe.AuthorId);
                recipe.Category = _categoryRepository.GetById(recipe.CategoryId);
                recipe.Ratings = _ratingRepository.GetByIdRecipe(recipe.Id);
            }
            return recipes;
        }

        public List<Recipe> RecipesApprovedById()
        {
            var recipes = _recipeRepository.RecipesApprovedById();
            foreach (var recipe in recipes)
            {
                recipe.Author = _userRepository.GetById(recipe.AuthorId);
                recipe.Category = _categoryRepository.GetById(recipe.CategoryId);
                recipe.Ratings = _ratingRepository.GetByIdRecipe(recipe.Id);
            }
            return recipes;
        }

        public List<Recipe> RecipesUnapproved()
        {
            var recipes = _recipeRepository.RecipesUnapproved();
            foreach (var recipe in recipes)
            {
                recipe.Author = _userRepository.GetById(recipe.AuthorId);
                recipe.Category = _categoryRepository.GetById(recipe.CategoryId);
                recipe.Ratings = _ratingRepository.GetByIdRecipe(recipe.Id);
            }
            return recipes;
        }

        public Recipe Save(Recipe recipe)
        {
            if (recipe.Id > 0)
                return _recipeRepository.Update(recipe);
            else
                return _recipeRepository.Add(recipe);
        }

        public void Delete(int Id)
        {
            _recipeRepository.Delete(Id);
        }

        public Recipe LastRecipe()
        {
            return _recipeRepository.LastRecipe();
        }
    }

}
