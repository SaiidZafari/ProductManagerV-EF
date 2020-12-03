using System.Collections.Generic;

namespace ProductManagerV_EF.Model
{
    public class Category
    {
        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Inventory { get; set; }

        public IList<CategorySubCategory> CategorySubCategories { get; set; }

        public IList<ProductCategory> ProductCategories { get; set; }
    }
}
