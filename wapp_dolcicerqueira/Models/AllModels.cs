using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Models
{
    public class AllModels
    {
        public Users User { get; set; }

        public static Users UserCheck { get; set; }

        public Recipe Recipe { get; set; }
        
        public List<Recipe> Recipes { get; set; }

        public List<Recipe> RecipesaApproved { get; set; }
        public List<Recipe> RecipesaApprovedById { get; set; }

        public List<Recipe> RecipesUnapproved { get; set; }

        public List<Users> Users { get; set; }

        public List<Category> Categories { get; set; }

        public Category Category { get; set; }

        public Rating Rating { get; set; }

        public List<Rating> Ratings { get; set; }
        public List<Rating> RatingsById { get; set; }

        public int RatingAVG { get; set; }

        public List<LIngredients> LIngredients { get; set;}

        public LIngredients AddLIngredients { get; set; }

        public List<Ingredient> Ingredients { get; set;}

        public Ingredient Ingredient { get; set; }

        public List<Product> Products { get; set; }

        public Product Product { get; set; }

        public List<Measure> Measures { get; set; }

        public List<int> tempIng { get; set; }

        public SearchResults SearchResults { get; set; }

        public List<Favorite> Favorites { get; set; }

        public List<Friends> Friends { get; set; }

        public Friends Friend { get; set; }


    }
}
