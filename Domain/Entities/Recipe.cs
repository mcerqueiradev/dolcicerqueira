using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Users Author { get; set; }
        public DateTime Data { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<LIngredients> ListIngredients { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        public List<Rating> Ratings { get; set; }
        public DateTime PreparationTime { get; set; }
        public int Portions { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Upload { get; set; }

        public bool IsApproved { get; set; }

    }
}
