using ProductManagerV_EF.Domain.Product;
using ProductManagerV_EF.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ProductManagerV_EF.Domain.Category
{
    class CategoryMenu
    {
        public static bool ProductToCategory()
        {
            var db = new AppDbContext();
            Console.Clear();
            Console.SetCursorPosition(37, 1);
            Console.WriteLine(">>  Add Product To Category  <<");

            PrintCategoryMethods.PrintCategoriesView(5, 8);

            ProductPrintMethods.PrintProductView(79, 8);

            Console.SetCursorPosition(5, 23);
            Console.WriteLine($@"Selected ID >");

            Regex selectedIdRegex = new Regex(@"\d$");
            string selectId;
            do
            {
                Console.SetCursorPosition(19, 23);
                Console.WriteLine("       ");
                Console.SetCursorPosition(19, 23);
                selectId = Console.ReadLine();
            } while (!selectedIdRegex.IsMatch(selectId ?? throw new InvalidOperationException()));

            int selectedId = int.Parse(selectId);

            var category = db.Categories.FirstOrDefault(c => c.CategoryId == selectedId);

            if (category != null)
            {
                Console.SetCursorPosition(5, 25);
                Console.WriteLine($@"[A] Add product");
                ConsoleKeyInfo escape;
                do
                {
                    Console.SetCursorPosition(20, 25);
                    Console.WriteLine("       ");
                    Console.SetCursorPosition(20, 25);
                    escape = Console.ReadKey();
                } while (escape.Key != ConsoleKey.A);

                Console.SetCursorPosition(42, 8);
                Console.WriteLine($"{"<<< Categories",17} ");

                Console.SetCursorPosition(42, 10);
                Console.WriteLine($"{"ID",10} : {category.CategoryId,-10}");
                Console.SetCursorPosition(42, 12);
                Console.WriteLine($"{"Category",10} : {category.CategoryName,-10}");

                Console.SetCursorPosition(42, 14);
                Console.WriteLine($"{"Proucts >>>",17} ");

                Console.SetCursorPosition(42, 16);
                Console.WriteLine($"{"ID",10} :");
                Console.SetCursorPosition(39, 18);
                Console.WriteLine($"{"FK_Categories",10} : {selectedId}");

                ProductPrintMethods.SearchProductsViews();

                Regex fkCategoryRegex = new Regex(@"^[0-9]+");
                string productid;
                do
                {
                    Console.SetCursorPosition(55, 16);
                    Console.WriteLine("                      ");
                    Console.SetCursorPosition(55, 16);
                    productid = Console.ReadLine();
                } while (!fkCategoryRegex.IsMatch(productid ?? string.Empty));

                int productId = int.Parse(productid ?? string.Empty);

                //bool answerReact;
                Regex answerRegex = new Regex(@"[YN]");
                string answer;
                do
                {
                    Console.SetCursorPosition(40, 25);
                    Console.WriteLine("Do you verify this change? Y/N: ");

                    Console.SetCursorPosition(72, 25);
                    Console.WriteLine("                                            ");
                    Console.SetCursorPosition(72, 25);
                    answer = Console.ReadLine().ToUpper();
                } while (!answerRegex.IsMatch(answer));

                Console.SetCursorPosition(40, 25);
                Console.WriteLine("                                           ");

                if (answer == "Y")
                {
                    var pc = db.ProductCategories.FirstOrDefault(x => x.CategoryId == selectedId);

                    var selectedProduct = db.Products.FirstOrDefault(p => p.ProductId == productId);

                    if (selectedProduct == null)
                    {
                        Console.SetCursorPosition(5, 24);
                        Console.WriteLine("Invalid ID ...   ");
                        Thread.Sleep(2000);

                        Console.SetCursorPosition(5, 24);
                        Console.WriteLine("                  ");
                    }
                    else if (pc != null && pc.CategoryId == selectedId && pc.ProductId == productId)
                    {
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine($"This combination is already Exist ! ");
                        Thread.Sleep(2000);
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine("                                       ");
                        //answerReact = false;
                        answer = "N";
                    }
                    else
                    {
                        db.ProductCategories.AddRange(new ProductCategory
                        {
                            ProductId = productId,
                            CategoryId = selectedId
                        });

                        db.SaveChanges();

                        ProductPrintMethods.CleanProductView(39, 8, 12);
                        PrintCategoryMethods.PrintChainProdToCatView(39, 8);
                    }

                }
                else
                {
                    Console.SetCursorPosition(5, 25);
                    Console.WriteLine("No change made ");
                    Thread.Sleep(2000);
                }

                ProductPrintMethods.PrintProductView(79, 8);

                Console.SetCursorPosition(5, 25);
                Console.WriteLine(" Press any key to continue ...      ");
                Console.SetCursorPosition(42, 25);
                Console.ReadKey();

            }
            else
            {
                Console.SetCursorPosition(5, 24);
                Console.WriteLine("Invalid ID ...   ");
                Thread.Sleep(2000);

                Console.SetCursorPosition(5, 24);
                Console.WriteLine("                  ");
            }

            return true;

        }


        public static bool SubCategoryToCategory()
        {
            var db = new AppDbContext();
            Console.Clear();
            Console.SetCursorPosition(37, 1);
            Console.WriteLine(">>  Add Category To SubCategory  <<");

            PrintCategoryMethods.PrintCategoriesView(5, 8);

            PrintCategoryMethods.PrintChainCatToSubView(66, 8);

            PrintCategoryMethods.PrintSubCategoriesView(100, 8);

            Console.SetCursorPosition(5, 23);
            Console.WriteLine($@"Selected ID >");

            Regex selectedIdRegex = new Regex(@"\d$");
            string selectId;
            do
            {
                Console.SetCursorPosition(19, 23);
                Console.WriteLine("       ");
                Console.SetCursorPosition(19, 23);
                selectId = Console.ReadLine();
            } while (!selectedIdRegex.IsMatch(selectId ?? throw new InvalidOperationException()));

            int selectedId = int.Parse(selectId);

            var category = db.Categories.FirstOrDefault(c => c.CategoryId == selectedId);

            if (category != null)
            {
                Console.SetCursorPosition(5, 25);
                Console.WriteLine($@"[A] Add SubCategory:");
                ConsoleKeyInfo escape;
                do
                {
                    Console.SetCursorPosition(25, 25);
                    Console.WriteLine("       ");
                    Console.SetCursorPosition(25, 25);
                    escape = Console.ReadKey();
                } while (escape.Key != ConsoleKey.A);

                Console.SetCursorPosition(42, 8);
                Console.WriteLine($"{"<<< Categories",17} ");

                Console.SetCursorPosition(42, 10);
                Console.WriteLine($"{"ID",10} : {category.CategoryId,-10}");
                Console.SetCursorPosition(42, 12);
                Console.WriteLine($"{"Category",10} : {category.CategoryName,-10}");

                Console.SetCursorPosition(42, 14);
                Console.WriteLine($"{"SubCategory >>>",17} ");

                Console.SetCursorPosition(42, 16);
                Console.WriteLine($"{"ID",10} :");
                Console.SetCursorPosition(39, 18);
                Console.WriteLine($"{"FK_Categories",10} : {selectedId}");

                PrintCategoryMethods.SearchSubcategoryViews();

                Regex fkCategoryRegex = new Regex(@"^[0-9]+");
                string subid;
                do
                {
                    Console.SetCursorPosition(55, 16);
                    Console.WriteLine("                      ");
                    Console.SetCursorPosition(55, 16);
                    subid = Console.ReadLine();
                } while (!fkCategoryRegex.IsMatch(subid ?? string.Empty));

                int subId = int.Parse(subid ?? string.Empty);

                //bool answerReact;
                Regex answerRegex = new Regex(@"[YN]");
                string answer;
                do
                {
                    Console.SetCursorPosition(40, 25);
                    Console.WriteLine("Do you verify this change? Y/N: ");

                    Console.SetCursorPosition(72, 25);
                    Console.WriteLine("                                            ");
                    Console.SetCursorPosition(72, 25);
                    answer = Console.ReadLine().ToUpper();
                } while (!answerRegex.IsMatch(answer));

                Console.SetCursorPosition(40, 25);
                Console.WriteLine("                                           ");


                if (answer == "Y")
                {
                    var pc = db.CategorySubCategories.FirstOrDefault(x => x.CategoryId == selectedId);

                    var selectedSubCategory = db.SubCategories.FirstOrDefault(sc => sc.SubCategoryId == subId);

                    if (selectedSubCategory == null)
                    {
                        Console.SetCursorPosition(5, 24);
                        Console.WriteLine("Invalid ID ...   ");
                        Thread.Sleep(2000);

                        Console.SetCursorPosition(5, 24);
                        Console.WriteLine("                  ");
                    }
                    else if (pc.CategoryId == selectedId && pc.SubCategoryId == subId)
                    {
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine($"This combination is already Exist ! ");
                        Thread.Sleep(2000);
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine("                                       ");
                        //answerReact = false;
                        answer = "N";
                    }
                    else
                    {
                        db.CategorySubCategories.AddRange(new CategorySubCategory
                        {
                            SubCategoryId = subId,
                            CategoryId = selectedId
                        });

                        db.SaveChanges();

                        ProductPrintMethods.CleanProductView(66, 8, 12);
                        PrintCategoryMethods.PrintChainCatToSubView(66, 8);
                    }
                }
                else
                {
                    Console.SetCursorPosition(5, 25);
                    Console.WriteLine("No change made ");
                    Thread.Sleep(2000);
                }

                PrintCategoryMethods.PrintSubCategoriesView(100, 8);

                Console.SetCursorPosition(5, 25);
                Console.WriteLine(" Press any key to continue ...      ");
                Console.SetCursorPosition(42, 25);
                Console.ReadKey();


            }
            else
            {
                Console.SetCursorPosition(5, 24);
                Console.WriteLine("Invalid ID ...   ");
                Thread.Sleep(2000);

                Console.SetCursorPosition(5, 24);
                Console.WriteLine("                  ");
            }

            return true;
        }
    }
}
