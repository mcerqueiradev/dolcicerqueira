using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ILIngredientsService _lingredientsService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IRatingService _ratingService;
        private readonly IIngredientService _ingredientService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMeasureService _measureService;

        public RecipeController(IWebHostEnvironment webHostEnvironment, IRecipeService recipeService, ILIngredientsService lingredientsService, IUserService userService, ICategoryService categoryService, IRatingService ratingService, IIngredientService ingredientService, IMeasureService measureService)
        {
            _recipeService = recipeService;
            _lingredientsService = lingredientsService;
            _userService = userService;
            _categoryService = categoryService;
            _ratingService = ratingService;
            _ingredientService = ingredientService;
            _webHostEnvironment = webHostEnvironment;
            _measureService = measureService;
        }

        public IActionResult Recipe()
        {
            return View(); 
        }

        public IActionResult CreateRecipe(Recipe recipe)
        {

            AllModels am = new AllModels();
            // Check if the user is logged in
            int idUser;
            if (!int.TryParse(Request.Cookies["Id"], out idUser))
            {
                return RedirectToAction("Index", "Login");
            }

            am.User = _userService.GetById(idUser);
            am.Recipe = recipe;
            am.Recipe.AuthorId = idUser;
            am.Categories = _categoryService.GetAll();
            return View(am);
        }

        [HttpPost]
        public IActionResult AddComment(int rating, int recipeId, string commentText)
        {
            int idUser;
            if (!int.TryParse(Request.Cookies["Id"], out idUser))
            {
                return RedirectToAction("Index", "Login");
            }

            var comment = new Rating
            {
                Ratings = rating,
                RecipeId = recipeId,
                AuthorId = idUser,
                Comment = commentText
            };

            _ratingService.Save(comment);

            return RedirectToAction("GetById", "Recipe", new { id = recipeId });
        }

        public IActionResult GetByCategory(string category)
        {
            var recipes = _recipeService.GetByCategory(category);
            return View(recipes);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            AllModels am = new AllModels();
            am.Recipe = _recipeService.GetById(Id);
            am.RatingAVG = _ratingService.GetRatingAvg(am.Recipe.Ratings);
            am.Recipe.Category = _categoryService.GetById(am.Recipe.CategoryId);
            am.Recipe.Ratings = _ratingService.GetByIdRecipe(am.Recipe.Id);
            Response.Cookies.Append("RecipeId", am.Recipe.Id.ToString(), options);
            return View(am);
        }

        public IActionResult GetAll()        
        {
            AllModels am = new AllModels();
            am.RecipesaApproved = _recipeService.RecipesApproved();
            return View(am);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRecipe(Recipe recipe, int value, string commentText)
        {
            int idUser;
            if (!int.TryParse(Request.Cookies["Id"], out idUser))
            {
                return RedirectToAction("Index", "Login");
            }
            recipe.AuthorId = idUser;

            await SaveImage(recipe);
            int recipeId = _recipeService.Save(recipe).Id;
            return RedirectToAction("Add", "LIngredients");

        }

        [HttpPost]
        public async Task<IActionResult> SaveImage([FromForm] Recipe recipe)
        {
            if (recipe.Upload == null || recipe.Upload.Length == 0)
            {
                ModelState.AddModelError("Upload", "Nenhuma imagem selecionada");
            }

            // Verifica a extensão do arquivo para garantir que seja uma imagem
            string fileExtension = Path.GetExtension(recipe.Upload.FileName).ToLower();
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                ModelState.AddModelError("Upload", "Somente arquivos de imagem .jpg, .jpeg ou .png são permitidos");
            }

            // Gera um nome único para o arquivo de imagem
            string fileName = $"{Guid.NewGuid().ToString()}{fileExtension}";

            // Salva o arquivo de imagem na pasta "images" no diretório raiz do projeto
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await recipe.Upload.CopyToAsync(stream);
            }

            // Atribui o nome do arquivo ao objeto Recipe para salvar no banco de dados
            recipe.ImageUrl = fileName;

            // Salva o objeto Recipe no banco de dados
            // ...

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            if (AllModels.UserCheck != null)
            {
                Recipe recipe = _recipeService.GetById(id);
                return View(recipe);
            }

            return View();
        }
        [HttpPost]
        public IActionResult UpdateRecipe(Recipe recipe)
        {
            if (AllModels.UserCheck.UserAdmin == true)
            {
                _recipeService.Save(recipe);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
