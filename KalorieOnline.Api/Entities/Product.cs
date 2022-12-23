namespace KalorieOnline.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Calories { get; set; }
        public double Carbo { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public int CategoryId { get; set; }
    }
}
