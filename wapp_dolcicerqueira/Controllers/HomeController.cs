using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDashboardService _dashboardService;
        private readonly IRatingService _ratingService;
        private readonly IProductService _productService;
        private readonly IFavoriteService _favoriteService;
        private readonly ITestemonialsService _testemonialsService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IRecipeService recipeService, IUserService userService, ICategoryService categoryService, IDashboardService dashboardService, IRatingService ratingService, IProductService productService, IFavoriteService favoriteService, ITestemonialsService testemonialsService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _recipeService = recipeService;
            _userService = userService;
            _categoryService = categoryService;
            _dashboardService = dashboardService;
            _ratingService = ratingService;
            _productService = productService;
            _favoriteService = favoriteService;
            _testemonialsService = testemonialsService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            AllModels am = new AllModels();
            am.Recipes = _recipeService.GetAll();
            am.Categories = _categoryService.GetAll();
            am.Products = _productService.GetAll();
            am.RecipesaApproved = _recipeService.RecipesApproved();
            return View(am);
        }

        public IActionResult Search(string searchTerm)
        {
            var recipes = _recipeService.Search(searchTerm).ToList();
            var products = _productService.Search(searchTerm).ToList();
            var searchResults = new SearchResults
            {
                SearchTerm = searchTerm,
                Recipes = recipes,
                Products = products
            };
            var allModels = new AllModels
            {
                SearchResults = searchResults
            };

            foreach (var recipe in recipes)
            {
                recipe.Author = _userService.GetById(recipe.AuthorId);
                recipe.Category = _categoryService.GetById(recipe.CategoryId);
                recipe.Ratings = _ratingService.GetByIdRecipe(recipe.Id);
            }

            foreach (var product in products)
            {
                product.Category = _categoryService.GetById(product.CategoryId);
            }

            return View(allModels);
        }

        public IActionResult Dashboard()
        {
            int idUser;
            if (int.TryParse(Request.Cookies["Id"], out idUser))
            {
                AllModels am = new AllModels();
                am.User = _userService.GetById(idUser);
                AllModels.UserCheck = am.User;
                am.Users = _userService.GetAll();
                am.Recipes = _dashboardService.GetRecipes();
                am.Ratings = _ratingService.GetAll();
                am.Favorites = _favoriteService.GetFavoriteUser(idUser);
                am.RecipesUnapproved = _recipeService.RecipesUnapproved();
                am.RecipesaApproved = _recipeService.RecipesApproved();
                am.RecipesaApprovedById = am.RecipesaApproved.Where(r => r.AuthorId == idUser && r.IsApproved).ToList();
                am.RatingsById = am.Ratings.Where(r => r.AuthorId == idUser).ToList();
                return View(am);
            }

            return RedirectToAction("Index", "Login");
        }

        public IActionResult SaveFavorite(Favorite favorite)
        {
            int RecipeId;
            if (int.TryParse(Request.Cookies["IdRecipe"], out RecipeId))
            {
                if (AllModels.UserCheck != null)
                {
                    favorite.UserId = AllModels.UserCheck.Id;
                    favorite.RecipeId = RecipeId;
                    _favoriteService.Save(favorite);
                }

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "User");
        }

        public IActionResult ClearAuthorId()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
