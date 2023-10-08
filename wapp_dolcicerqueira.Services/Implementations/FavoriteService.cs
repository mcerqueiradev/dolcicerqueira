using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository, IRecipeRepository recipeRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _favoriteRepository = favoriteRepository;
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public Favorite GetById(int id)
        {
            return _favoriteRepository.GetById(id);
        }

        public List<Favorite> GetFavoriteUser(int id)
        {
            List<Favorite> favoritesRecipe = _favoriteRepository.GetFavoriteUser(id);

            foreach (var item in favoritesRecipe)
            {
                item.Recipe = _recipeRepository.GetById(item.RecipeId);
                item.Recipe.Author = _userRepository.GetById(item.Recipe.AuthorId);
                item.Recipe.Category = _categoryRepository.GetById(item.Recipe.CategoryId);
            }

            return favoritesRecipe;
        }

        public List<Favorite> GetAll()
        {
            return _favoriteRepository.GetAll();
        }

        public Favorite Save(Favorite favorite)
        {
            if (favorite.FavoriteId > 0)
                return _favoriteRepository.Update(favorite);
            else
                return _favoriteRepository.Add(favorite);
        }

        public Favorite Update(Favorite favorite)
        {
            return _favoriteRepository.Update(favorite);
        }
        public void Delete(int id)
        {
            _favoriteRepository.Delete(id);
        }

    }
}
