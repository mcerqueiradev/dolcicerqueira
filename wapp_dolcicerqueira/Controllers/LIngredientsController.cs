using Microsoft.AspNetCore.Mvc;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Implementations;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class LIngredientsController : Controller
    {
        private readonly ILIngredientsService _lingredientsService;
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;
        public LIngredientsController(ILIngredientsService lingredientsService, IRecipeService recipeService, IIngredientService ingredientService, IMeasureService measureService)
        {
            _lingredientsService = lingredientsService;
            _recipeService = recipeService;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public IActionResult Add(LIngredients lIngredients)
        {
            AllModels am = new AllModels();
            am.AddLIngredients = lIngredients;
            am.AddLIngredients = _lingredientsService.Add();
            am.AddLIngredients.Ingredients = _ingredientService.GetAll();
            am.AddLIngredients.Measures = _measureService.GetAll();

            Recipe recipe = _recipeService.LastRecipe();
            am.Recipe = recipe;
            am.AddLIngredients.RecipeId = recipe.Id;
            am.LIngredients = _lingredientsService.SelectIngredientByRecipe(recipe.Id);
            return View(am);
        }

        [HttpPost]
        public IActionResult SaveIngredients(AllModels am, int RecipeId)
        {
            Recipe recipe = _recipeService.LastRecipe();
            am.AddLIngredients.RecipeId = recipe.Id;
            _lingredientsService.Save(am.AddLIngredients);
            return RedirectToAction("Add");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
