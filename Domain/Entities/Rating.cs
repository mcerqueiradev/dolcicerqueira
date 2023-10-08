using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Ratings { get; set; }
        public string Comment { get; set; }
        public int RecipeId { get; set; }
        public int AuthorId { get; set; }
        public Users Author { get; set; }
    }
}
