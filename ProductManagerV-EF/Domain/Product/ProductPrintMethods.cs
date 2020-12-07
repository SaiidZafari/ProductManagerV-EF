using ProductManagerV_EF.Model;
using System;
using System.Linq;
using System.Threading;

namespace ProductManagerV_EF.Domain.Product
{
    class ProductPrintMethods
    {
        //private static AppDbContext db = new AppDbContext();

        public static void PrintProductView(int left, int top)
        {
            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"ID",-4}{"Name",-15}{"Material",-11}{"Color",-8}");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 37));
            int n = 0;
            if (db.Products.Any())
            {
                foreach (var product in db.Products)
                {
                    Console.SetCursorPosition(left, top + 2 + n);
                    Console.WriteLine($"{product.ProductId,-4}{product.Name,-15}{product.Material,-11}{product.Color,-8}");
                    n++;
                }
            }
            else
            {
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("   The Database Is Empty");
            }

        }

        private static void PrintProductViewsp(int left, int top, IQueryable<Model.Product> value)
        {
            var db = new AppDbContext();

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{"ID",-4}{"Name",-15}{"Material",-11}{"Color",-8}");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine(new string('=', 37));
            int n = 0;
            if (db.Products.Any())
            {
                foreach (var pro in value)
                {
                    Console.SetCursorPosition(left, top + 2 + n);
                    Console.WriteLine($"{pro.ProductId,-4}{pro.Name,-15}{pro.Material,-11}{pro.Color,-8}");
                    n++;
                }
            }
            else
            {
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine("   The Database Is Empty");
            }
        }

        public static void CleanProductView(int left, int top, int rowNumToClean)
        {
            int rowNum = top + rowNumToClean;
            for (int i = top; i < rowNum; i++)
            {
                Console.SetCursorPosition(left, i);
                Console.WriteLine("                                              ");
            }

        }
        
        public static void SearchProductsViews()
        {
            bool exit;

            string sqlQuerysp;

            do
            {
                Console.SetCursorPosition(5, 23);
                Console.WriteLine("Please choose view base on one of the options below");
                Console.SetCursorPosition(5, 25);
                Console.Write("[A]ll [N]ame [M]aterial [C]olor [E]xit:                 ");

                ConsoleKeyInfo viewOption;

                do
                {
                    Console.SetCursorPosition(48, 25);
                    Console.WriteLine("              ");
                    Console.SetCursorPosition(48, 25);
                    viewOption = Console.ReadKey();

                } while (viewOption.KeyChar.ToString() == "A" || viewOption.KeyChar.ToString() == "N" || viewOption.KeyChar.ToString() == "M" || viewOption.KeyChar.ToString() == "E");

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
                        PrintProductView(71, 8);
                        exit = true;
                        break;
                    case ConsoleKey.N:
                        CleanProductView(71,10,8);
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine($@"Please insert the name you wish :");
                        Console.SetCursorPosition(40, 25);
                        string name = Console.ReadLine();
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine("                 ");
                        //sqlQuerysp = "Select * From Products where Name = @parameter ";
                        var productName = dbFilter.Products.Where(p => p.Name == name);
                        PrintProductViewsp(71, 8, productName);
                        exit = true;
                        break;
                    case ConsoleKey.M:
                        CleanProductView(71,10,8);
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine("Please insert the Material you wish :");
                        Console.SetCursorPosition(43, 25);
                        string material = Console.ReadLine();
                        Console.SetCursorPosition(43, 25);
                        Console.WriteLine("                 ");
                        //sqlQuerysp = "Select * From Products where Material= @parameter ";
                        var productMaterial = dbFilter.Products.Where(p => p.Material == material);
                        PrintProductViewsp(71, 8, productMaterial);
                        exit = true;
                        break;
                    case ConsoleKey.C:
                        CleanProductView(71,10,8);
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine("Please insert the color you wish :");
                        Console.SetCursorPosition(40, 25);
                        string color = Console.ReadLine();
                        Console.SetCursorPosition(40, 25);
                        Console.WriteLine("                 ");
                        //sqlQuerysp = "Select * From Products where Color = @parameter ";
                        var productColor = dbFilter.Products.Where(p => p.Color == color);
                        PrintProductViewsp(71, 8, productColor);
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
        
        public static void ProductsView()
        {
            var db = new AppDbContext();

            if (db.Products.Any())
            {
                Console.WriteLine($"{"",1}{"ID",-4}{"Article Number",-17}{"Name",-15}{"Material",-10}{"Color",-10}{"Price",-10}{"Description",-10}");

                Console.WriteLine($"{"",3}{new string('=', 80)}");

                foreach (var product in db.Products)
                {
                    Console.WriteLine($"{"",3}{product.ProductId,-4}{product.ArticleNumber,-17}{product.Name,-15}{product.Material,-10}{product.Color,-10}{product.Price,-10}{product.Description,-10}");
                }
            }
            else
            {
                Console.WriteLine($"{"Article Number",-16}{"Name",-15}{"Price",-10}{"Description",-10}");

                Console.WriteLine(new string('=', 86));

                Console.WriteLine("The Database is Empty!");
            }

        }

        public static int GetCategoryid(int productId)
        {
            var db = new AppDbContext();
            int categoryId = 0;
            foreach (var pc in db.ProductCategories)
            {
                if (pc.ProductId == productId)
                {
                    categoryId = pc.CategoryId;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return categoryId;
        }
    }
}
