﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagerV_EF.Model
{
    public class SubCategory
    {
       
        public int SubCategoryId { get; set; }
        public string Name { get; set; }

        public IList<CategorySubCategory> CategorySubCategories { get; set; }
    }
}
