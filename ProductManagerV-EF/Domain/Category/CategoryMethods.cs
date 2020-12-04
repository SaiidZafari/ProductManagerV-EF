using ProductManagerV_EF.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ProductManagerV_EF.Domain.Category
{
    class CategoryMethods
    {
        public static void AddCategoryMenu()
        {

            var db = new AppDbContext();

            Console.SetCursorPosition(5, 2);
            Console.WriteLine("Please Insert a Category Name: ");

            PrintCategoryMethods.PrintCategoriesView(5, 10);

            Console.SetCursorPosition(36, 2);

            Model.Category category = new Model.Category(Console.ReadLine());

            Console.SetCursorPosition(5, 4);
            Console.WriteLine("Would you Confirm to add this category? Y/N: ");


            Regex confirmRegex = new Regex(@"[YN]$");
            ConsoleKeyInfo confirm;
            do
            {
                Console.SetCursorPosition(50, 4);
                confirm = Console.ReadKey();

            } while (!confirmRegex.IsMatch(confirm.Key.ToString()));

            if (confirm.Key == ConsoleKey.Y)
            {
                var newCategory = db.Categories.FirstOrDefault(sc => sc.CategoryName == category.CategoryName);

                if (newCategory == null)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("                                                     ");
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("A category added to the database.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("                                                     ");
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("Category already exists.");
                    Thread.Sleep(2000);
                }
            }

            PrintCategoryMethods.PrintCategoriesView(5, 10);
        }

        public static void AddSubCategoryMenu()
        {

            var db = new AppDbContext();

            Console.SetCursorPosition(5, 2);
            Console.WriteLine("Please Insert a SubCategory Name: ");

            PrintCategoryMethods.PrintSubCategoriesView(5, 10);

            Console.SetCursorPosition(39, 2);

            SubCategory subCategory = new SubCategory(Console.ReadLine());

            Console.SetCursorPosition(5, 4);
            Console.WriteLine("Would you Confirm to add this subcategory? Y/N: ");


            Regex confirmRegex = new Regex(@"[YN]$");
            ConsoleKeyInfo confirm;
            do
            {
                Console.SetCursorPosition(53, 4);
                confirm = Console.ReadKey();

            } while (!confirmRegex.IsMatch(confirm.Key.ToString()));

            if (confirm.Key == ConsoleKey.Y)
            {

                var newSubCategory = db.SubCategories.FirstOrDefault(sc => sc.Name == subCategory.Name);

                if (newSubCategory == null)
                {
                    db.SubCategories.Add(subCategory);
                    db.SaveChanges();
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("                                                     ");
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("A subcategory added to the database.");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("                                                     ");
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("Category already exists.");
                    Thread.Sleep(2000);
                }
            }

            PrintCategoryMethods.PrintSubCategoriesView(5, 10);
        }
    }
}
