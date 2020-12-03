using System;
using System.Text.RegularExpressions;
using System.Threading;
using ProductManagerV_EF.Domain.Category;
using ProductManagerV_EF.Domain.Enums;
using ProductManagerV_EF.Domain.Product;
using ProductManagerV_EF.Model;

namespace ProductManagerV_EF
{
    class Program
    {
        static void Main(string[] args)
        {

            int left = 2;
            int top = 3;

            var db = new AppDbContext();

            bool leaveHeadMenu = false;

            do
            {
                Console.Clear();

                Console.SetCursorPosition(38, 1);
                Console.WriteLine(">>  Product Manager Central Menu  <<");

                Console.SetCursorPosition(0, 5);
                Console.WriteLine($@"
        1. Categories

        2. Articles

        3. Exit

        Please Choose One of Options above: ");

                Regex menuOptionRegex = new Regex(@"[1-3]$");
                string menuOption;
                do
                {
                    Console.SetCursorPosition(44, 12);
                    menuOption = Console.ReadKey().KeyChar.ToString();
                } while (!menuOptionRegex.IsMatch(menuOption));

                Console.Clear();

                EnumsMethods.MenuOptions menuOptions = (EnumsMethods.MenuOptions)int.Parse(menuOption) - 1;

                bool doCaseOneAgain;
                switch (menuOptions)
                {
                    case EnumsMethods.MenuOptions.Categories:

                        do
                        {
                            Console.Clear();

                            Console.SetCursorPosition(37, 1);
                            Console.WriteLine(">>  Add Categories and Products  <<");

                            Console.SetCursorPosition(95, 1);
                            Console.WriteLine("Push [Esc] to Exit ");

                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine($@"
        1. Add category

        2. Add subCategory

        3. List categories

        4. Add product to category

        5. Add category to subcategory

        Please Choose One of Options above: ");

                            Regex menuOption2Regex = new Regex(@"[123456]$");
                            ConsoleKeyInfo categoryMenuOption;
                            do
                            {
                                Console.SetCursorPosition(44, 16);
                                categoryMenuOption = Console.ReadKey();

                                if (categoryMenuOption.Key == ConsoleKey.Escape)
                                {
                                    categoryMenuOption = new ConsoleKeyInfo('6', ConsoleKey.D6, false, false, false);
                                }

                            } while (!menuOption2Regex.IsMatch(categoryMenuOption.KeyChar.ToString()));

                            Console.Clear();
                            EnumsMethods.CategoryMenuOption categoryMenuOptions =
                                (EnumsMethods.CategoryMenuOption)int.Parse(categoryMenuOption.KeyChar.ToString()) - 1;

                            switch (categoryMenuOptions)
                            {
                                case EnumsMethods.CategoryMenuOption.Addcategory:
                                    CategoryMethods.AddCategoryMenu();
                                    doCaseOneAgain = true;
                                    Console.WriteLine($@"



     Press any key to continue ...");
                                    Console.ReadKey();
                                    break;
                                case EnumsMethods.CategoryMenuOption.AddsubCategory:
                                    CategoryMethods.AddSubCategoryMenu();
                                    doCaseOneAgain = true;
                                    Console.WriteLine($@"



     Press any key to continue ...");
                                    Console.ReadKey();
                                    break;
                                case EnumsMethods.CategoryMenuOption.Listcategories:
                                    Console.Clear();
                                    Console.SetCursorPosition(35, 1);
                                    Console.WriteLine(">>  Category and SubCategory Tables  <<");

                                    PrintCategoryMethods.PrintCategoriesView(25, 8);

                                    PrintCategoryMethods.PrintSubCategoriesView(75, 8);

                                    doCaseOneAgain = true;

                                    Console.SetCursorPosition(5, 24);
                                    Console.WriteLine($@"Press Esc to continue ...");
                                    //Regex escapeRegex = new Regex(@"[12345]$");
                                    ConsoleKeyInfo escape;
                                    do
                                    {
                                        Console.SetCursorPosition(30, 24);
                                        Console.WriteLine("       ");
                                        Console.SetCursorPosition(30, 24);
                                        escape = Console.ReadKey();

                                    } while (escape.Key != ConsoleKey.Escape);


                                    break;
                                case EnumsMethods.CategoryMenuOption.AddProductToCategory:
                                    doCaseOneAgain = CategoryMenu.ProductToCategory();
                                    break;
                                case EnumsMethods.CategoryMenuOption.AddCategoryToCategory:

                                    CategoryMenu.SubCategoryToCategory();

                                    doCaseOneAgain = true;

                                    break;
                                case EnumsMethods.CategoryMenuOption.Exit:
                                    doCaseOneAgain = false;
                                    leaveHeadMenu = true;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                        } while (doCaseOneAgain);

                        break;
                    case EnumsMethods.MenuOptions.Articles:

                        Console.Clear();

                        //int successRow;

                        bool doItAgain = false;

                        ConsoleKeyInfo keySelectEdit = default;

                        do
                        {
                            Console.Clear();

                            Console.SetCursorPosition(45, 1);
                            Console.WriteLine(">>  Articles Central Menu  <<");

                            Console.WriteLine($@"

        1. Add article

        2. Search article

        3. Exit

        Please Choose one of the options above: ");

                            Regex optionRegex = new Regex(@"[1-3]$");
                            string option;
                            do
                            {
                                Console.SetCursorPosition(48, 10);
                                Console.WriteLine("  ");
                                Console.SetCursorPosition(48, 10);
                                option = Console.ReadKey().KeyChar.ToString().ToUpper();
                            } while (!optionRegex.IsMatch(option));

                            EnumsMethods.ArticleMenu articleMenu = (EnumsMethods.ArticleMenu)int.Parse(option) - 1;

                            switch (articleMenu)
                            {
                                case EnumsMethods.ArticleMenu.AddArticle:

                                    doItAgain = AddProducts.AddProduct(left, top, db);

                                    break;
                                case EnumsMethods.ArticleMenu.SearchArticle:

                                    doItAgain = SearchProducts.SearchProduct(left, top, db, keySelectEdit);

                                    break;
                                case EnumsMethods.ArticleMenu.Exit:
                                    doItAgain = false;
                                    break;
                            }

                        } while (doItAgain);

                        Console.Clear();
                        Console.WriteLine($@"

                            Product Manager v1.0 
                                         ADO.NET

                                        The End");

                        Console.SetCursorPosition(left, top + 12);
                        ProductPrintMethods.ProductsView();

                        Thread.Sleep(3000);

                        leaveHeadMenu = true;
                        break;
                    case EnumsMethods.MenuOptions.Exit:

                        leaveHeadMenu = false;

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            } while (leaveHeadMenu);


            Console.SetCursorPosition(45, 1);
            Console.WriteLine(">>  Database Tables  <<");

            Console.WriteLine($@"

            Categories                        CategoriesBridgeSubCategory                      Sub Categories   ");
            PrintCategoryMethods.PrintCategoriesView(5, 6);

            PrintCategoryMethods.PrintChainCatToSubView(46, 6);

            PrintCategoryMethods.PrintSubCategoriesView(95, 6);

            Console.SetCursorPosition(35, 15);
            Console.WriteLine("Products                                CategoriesBridgeProducts");
            ProductPrintMethods.PrintProductView(20, 17);
            PrintCategoryMethods.PrintChainProdToCatView(75, 17);
            Console.SetCursorPosition(0, 24);

            Console.WriteLine("\n");
        }
    }
    
}
