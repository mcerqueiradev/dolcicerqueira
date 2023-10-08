using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
