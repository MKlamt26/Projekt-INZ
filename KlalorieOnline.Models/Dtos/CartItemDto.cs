using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProduntId { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public double Calories { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double TotalCalories { get; set; }
        public double TotalCarbo { get; set; }
        public double TotalProtein { get; set; }
        public double TotalFat { get; set; }
        public int Qty { get; set; }
    }
}
