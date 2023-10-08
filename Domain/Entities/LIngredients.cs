using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class LIngredients
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string Unit { get; set; }
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public List<Measure> Measures { get; set; }
        public decimal Quantity { get; set; }
    }
}
