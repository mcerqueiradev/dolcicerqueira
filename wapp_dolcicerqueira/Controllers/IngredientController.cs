using Microsoft.AspNetCore.Mvc;
using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Models;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(Ingredient ingredient)
        {
            AllModels am = new AllModels();
            am.Ingredients = _ingredientService.GetAll();
            am.Ingredient = ingredient;       
            int idUser;
            if (!int.TryParse(Request.Cookies["Id"], out idUser))
            {
                return RedirectToAction("Index", "Login");
            }
            return View(am);
        }

        [HttpPost]
        public IActionResult Save(Ingredient ingredient)
        {
            var existingIngredient = _ingredientService.GetById(ingredient.Id);

            //if (existingIngredient != null)
            //{
            //    ModelState.AddModelError("Id", "The ingredient is already registered in the database.");
            //    return RedirectToAction("Add", "Ingredient");
            //}

            ingredient = _ingredientService.Save(ingredient);
            TempData["SuccessMessage"] = "Ingredient saved successfully!";
            return RedirectToAction("Add", "Ingredient");
        }

    }
}
