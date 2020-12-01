using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagerV_EF.Model
{
    public class CategorySubCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
