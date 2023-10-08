using System.Collections.Generic;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Models
{
    public class SearchResults
    {
        public string SearchTerm { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Product> Products { get; set; }
    }

}
