using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class FavoriteController : Controller
    {

        private readonly IFavoriteService _favoriteService;

        public FavoriteController (IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyFavorites()
        {
            int userId;
            if (int.TryParse(Request.Cookies["UserId"], out userId))
            {
                List<Favorite> favorite = _favoriteService.GetFavoriteUser(userId);
                return View(favorite);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult SaveFavorite(Favorite favorite)
        {
            int RecipeId;
            if (int.TryParse(Request.Cookies["RecipeId"], out RecipeId))
            {
                if (AllModels.UserCheck != null)
                {
                    favorite.UserId = AllModels.UserCheck.Id;
                    favorite.RecipeId = RecipeId;
                    _favoriteService.Save(favorite);
                }

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
