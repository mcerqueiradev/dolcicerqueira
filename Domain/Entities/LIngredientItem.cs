using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Domain.Entities
{
    public class LIngredientItem
    {
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public int MeasureId { get; set; }

        public LIngredientItem(int ingredientId, decimal quantity, int measureId) { 
            IngredientId = ingredientId;
            Quantity = quantity;
            MeasureId = measureId;
        }
    }
}
