using System.Collections.Generic;

namespace ProductManagerV_EF.Model
{
    public class Product
    {
        public Product(string articleNumber, string name, string material, string color, int price, string description)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Material = material;
            Color = color;
            Price = price;
            Description = description;
        }

        public int ProductId { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public IList<ProductCategory> ProductCategories { get; set; }
    }
}
