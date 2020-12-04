using ProductManagerV_EF.Model;
using System;
using System.Linq;
using System.Threading;
using ProductManagerV_EF.Domain.Product;

namespace ProductManagerV_EF.Domain.Category
{
    class PrintCategoryMethods
    {
        public static void PrintCategoriesView(int left, int top)
        {
            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"ID",-5}{"Category",-15}{"Inventory",-10}");

            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 30));

            int n = 0;

            foreach (var category in db.Categories)
            {
                Console.SetCursorPosition(left, top + 2 + n);
                Console.WriteLine(
                    $"{category.CategoryId,-5}{category.CategoryName,-15}{category.Inventory,-10}");
                n++;
            }

        }

        public static void PrintSubCategoriesView(int left, int top)
        {

            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"ID",-4}{"Name",-11}");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 13));
            int n = 0;
            foreach (var subCategory in db.SubCategories)
            {
                Console.SetCursorPosition(left, top + 2 + n);
                Console.WriteLine($"{subCategory.SubCategoryId,-4}{subCategory.Name,-11}");
                n++;
            }
        }

        public static void PrintChainCatToSubView(int left, int top)
        {
            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"Fk_Category",-15}{"FK_SubCategory",-13}");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 29));
            int n = 0;
            if (db.CategorySubCategories.Any())
            {
                foreach (var chain in db.CategorySubCategories)
                {
                    Console.SetCursorPosition(left, top + 2 + n);
                    Console.WriteLine(
                        $"{chain.CategoryId,-15}{chain.SubCategoryId,-15}");
                    n++;
                }
            }
            else
            {
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("   The Database Is Empty");
            }

        }

        public static void PrintChainProdToCatView(int left, int top)
        {
            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"Fk_Category",-15}{"FK_Product",-13}");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 27));
            int n = 0;
            if (db.ProductCategories.Any())
            {
                foreach (var chain in db.ProductCategories)
                {
                    Console.SetCursorPosition(left, top + 2 + n);
                    Console.WriteLine(
                        $"{chain.CategoryId,-15}{chain.ProductId,-15}");
                    n++;
                }
            }
            else
            {
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("   The Database Is Empty");
            }

        }

        private static void PrintSubCategoryViewsp(int left, int top, IQueryable<SubCategory> value)
        {
            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"ID",-4}{"Name",-11}");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 13));
            int n = 0;
            if (db.Products.Any())
            {
                foreach (var pro in value)
                {
                    Console.SetCursorPosition(left, top + 2 + n);
                    Console.WriteLine($"{pro.SubCategoryId,-4}{pro.Name,-15}");
                    n++;
                }
            }
            else
            {
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("   The Database Is Empty");
            }
        }

        public static void CleanSubCategoryView(int left, int top, int rowNumToClean)
        {
            int rowNum = top + rowNumToClean;
            for (int i = top; i < rowNum; i++)
            {
                Console.SetCursorPosition(left, i);
                Console.WriteLine("                   ");
            }

        }

        public static void SearchSubcategoryViews()
        {
            bool exit;

            do
            {
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("Please choose view base on one of the options below");
                Console.SetCursorPosition(5, 25);
                Console.Write("[A]ll [N]ame [E]xit:                 ");

                ConsoleKeyInfo viewOption;

                do
                {
                    Console.SetCursorPosition(26, 25);
                    Console.WriteLine("              ");
                    Console.SetCursorPosition(26, 25);
                    viewOption = Console.ReadKey();

                } while (viewOption.KeyChar.ToString() == "A" || viewOption.KeyChar.ToString() == "N" || viewOption.KeyChar.ToString() == "E");

                Console.SetCursorPosition(35, 25);
                Console.WriteLine("                 ");
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("                                                       ");
                Console.SetCursorPosition(5, 25);
                Console.WriteLine("                                                       ");

                var dbFilter = new AppDbContext();

                switch (viewOption.Key)
                {
                    case ConsoleKey.E:
                        exit = false;
                        break;
                    case ConsoleKey.A:
                        PrintSubCategoriesView(100, 8);
                        exit = true;
                        break;
                    case ConsoleKey.N:
                        CleanSubCategoryView(100, 10, 8);
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine($@"Please insert the name you wish :");
                        Console.SetCursorPosition(40, 25);
                        string nameSubCat = Console.ReadLine();
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine("                 ");

                        var subCategoryName = dbFilter.SubCategories.Where(p => nameSubCat != null && p.Name == nameSubCat);
                        PrintSubCategoryViewsp(100, 8, subCategoryName);
                        exit = true;
                        break;
                    
                    default:
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine("Invalid choice.                                        ");
                        Thread.Sleep(2000);
                        exit = true;
                        break;
                }
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("                                                       ");

                Console.SetCursorPosition(5, 25);
                Console.WriteLine("                                                       ");

            } while (exit);

            Console.SetCursorPosition(5, 23);
            Console.WriteLine("                                                       ");
            Console.SetCursorPosition(5, 25);
            Console.WriteLine("                                                       ");

        }

    }
}
