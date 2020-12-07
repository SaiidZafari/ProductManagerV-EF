using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ProductManagerV_EF.Model;

namespace ProductManagerV_EF.Domain.Product
{
    class SearchProducts
    {
        public static bool SearchProduct(int left, int top, AppDbContext db, ConsoleKeyInfo keySelectEdit)
        {
            bool doItAgain;
            do
            {
                doItAgain = false;
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.Write(" Please Enter Articel number you want to find:");

                Console.SetCursorPosition(left, top + 26);
                Console.WriteLine($"                    [EXIT] Main menu");

                Console.SetCursorPosition(left, top + 12);
                ProductPrintMethods.ProductsView();

                Regex articleNumberRegex =
                    new Regex(@"^[A-Za-z][0-9][0-9][0-9][a-zA-Z][0-9][0-9]$");
                string articleNumber;
                do
                {
                    Console.SetCursorPosition(left + 47, top);
                    Console.WriteLine("                     ");
                    Console.SetCursorPosition(left + 47, top);
                    articleNumber = Console.ReadLine().ToUpper();

                    if (articleNumber == "EXIT")
                    {
                        doItAgain = false;
                        articleNumber = "Z999Z99";
                    }
                } while (!articleNumberRegex.IsMatch(articleNumber ?? string.Empty));

                if (articleNumber != "Z999Z99")
                {
                    int productId = -1;


                    //var productToSearch = db.Products.FirstOrDefault(p => p.ArticleNumber == articleNumber);


                    foreach (var product in db.Products)
                    {
                        if (product.ArticleNumber == articleNumber)
                        {
                            productId = product.ProductId;
                        }
                    }

                    if (productId == -1)
                    {
                        Console.SetCursorPosition(left, top + 2);
                        Console.WriteLine(
                            "Article didn't find in this database.                       ");
                        Thread.Sleep(2000);
                        Console.SetCursorPosition(left, top + 2);
                        Console.WriteLine(
                            "                                                      ");
                        break;
                    }
                    else
                    {
                        //DataRow dataRows = dataSet.Tables["Products"].Rows[articleIndex];
                        Console.Clear();
                        Console.SetCursorPosition(left + 30, top);
                        Console.WriteLine(
                            $"Search result for Article Number {articleNumber} :");

                        if (db.Products.FirstOrDefault(x => x.ArticleNumber == articleNumber) ==
                            null)
                        {
                            Console.SetCursorPosition(left, top + 2);
                            Console.WriteLine(
                                "Article didn't find in this database.                       ");

                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("Press any key to continue .... ");

                            Console.SetCursorPosition(left + 31, top + 4);
                            Console.ReadKey();
                        }
                        else
                        {
                            Model.Product product = db.Products.FirstOrDefault(x =>
                                x.ArticleNumber == articleNumber);
                            Console.SetCursorPosition(left, top + 2);
                            Console.WriteLine(
                                $"{"Article number : ",17}{product.ArticleNumber}");

                            Console.SetCursorPosition(left + 40, top + 2);
                            Console.WriteLine($"{"Material : ",17}{product.Material}");

                            Console.SetCursorPosition(left, top + 4);
                            Console.WriteLine($"{"Name : ",17}{product.Name}");

                            Console.SetCursorPosition(left + 40, top + 4);
                            Console.WriteLine($"{"Color : ",17}{product.Color}");

                            Console.SetCursorPosition(left, top + 6);
                            Console.WriteLine($"{"Price : ",17}{product.Price}");

                            Console.SetCursorPosition(left + 40, top + 6);
                            Console.WriteLine(
                                $"{"Description : ",17}{product.Description}");

                            Console.SetCursorPosition(left, top + 12);
                            ProductPrintMethods.ProductsView();

                            Console.SetCursorPosition(left, top + 26);
                            Console.WriteLine($"[E] Edit [D] Delete [Esc] Main menu");

                            Console.SetCursorPosition(left + 36, top + 26);

                            Regex keySelectEditRegex = new Regex(@"(E|D|Escape)$");

                            do
                            {
                                keySelectEdit = Console.ReadKey(true);
                            } while (!keySelectEditRegex.IsMatch(keySelectEdit.Key.ToString()));

                            if (keySelectEdit.Key == ConsoleKey.Escape)
                            {
                                //doItAgain = true;
                                break;
                            }
                            else if (keySelectEdit.Key == ConsoleKey.D)
                            {
                                Console.SetCursorPosition(left, top + 26);
                                Console.Write(
                                    "Are you sue you want to delete this article? Y/N: ");

                                Regex keySelectYoNRegex = new Regex(@"[YN]$");
                                ConsoleKeyInfo keyYoN;
                                do
                                {
                                    Console.SetCursorPosition(left + 50, top + 26);
                                    keyYoN = Console.ReadKey(true);
                                } while (!keySelectYoNRegex.IsMatch(keyYoN.Key.ToString()));


                                Console.SetCursorPosition(left, top + 26);
                                Console.WriteLine(
                                    $"[E] Edit [D] Delete [Esc] Main menu                           ");

                                var productToDelete = db.Products.FirstOrDefault(p => p.ArticleNumber == articleNumber);

                                if (keyYoN.Key == ConsoleKey.Y)
                                {
                                    db.Products.Remove(productToDelete);
                                    db.SaveChanges();
                                }
                            }
                            else if (keySelectEdit.Key == ConsoleKey.E)
                            {
                                //DataRow oldDataRow = dataSet.Tables["Products"].Rows[articleIndex];

                                bool keyOption = false;
                                do
                                {
                                    //db.Products.AddRange(new Product
                                    //{

                                    //});

                                    //db.Products.Add(new Product
                                    //{

                                    //    Name = product.Name,
                                    //    Price = product.Price,
                                    //    Material = product.Material,
                                    //    Color = product.Color,
                                    //    Description = product.Description
                                    //});

                                    Console.SetCursorPosition(left, top + 26);
                                    Console.WriteLine(
                                        $"[N]ame [P]rice [M]aterial [C]olor [D]escription  [Q]uit  Please choose your Option to Edit: ");


                                    Regex keyInfoRegex = new Regex(@"[NnPpMmCcDdQq]$");
                                    ConsoleKeyInfo keyInfo;
                                    do
                                    {
                                        Console.SetCursorPosition(left + 92, top + 26);
                                        Console.WriteLine("     ");
                                        Console.SetCursorPosition(left + 92, top + 26);
                                        keyInfo = Console.ReadKey();
                                    } while (!keyInfoRegex.IsMatch(keyInfo.KeyChar.ToString()));

                                    Console.SetCursorPosition(left + 92, top + 26);
                                    Console.WriteLine("                 ");

                                    var productToSearch = db.Products.FirstOrDefault(p => p.ArticleNumber == articleNumber);

                                    switch (keyInfo.Key)
                                    {
                                        case ConsoleKey.Q:
                                            doItAgain = false;
                                            keyOption = false;
                                            break;
                                        case ConsoleKey.N:
                                            productToSearch.Name =
                                                ProductMethods.AddName(left - 1, top);
                                            keyOption = true;
                                            break;
                                        case ConsoleKey.P:
                                            productToSearch.Price =
                                                ProductMethods.AddPrice(left - 1, top);
                                            keyOption = true;
                                            break;
                                        case ConsoleKey.M:
                                            productToSearch.Material =
                                                ProductMethods.AddMaterial(left - 1, top);
                                            keyOption = true;
                                            break;
                                        case ConsoleKey.C:
                                            productToSearch.Color =
                                                ProductMethods.AddColor(left - 1, top);
                                            keyOption = true;
                                            break;
                                        case ConsoleKey.D:
                                            productToSearch.Description =
                                                ProductMethods.AddDescription(left - 1, top);
                                            keyOption = true;
                                            break;
                                        default:
                                            Console.SetCursorPosition(left + 92, top + 26);
                                            Console.WriteLine("Invalid key ...");
                                            Thread.Sleep(2000);
                                            Console.SetCursorPosition(left + 92, top + 26);
                                            Console.WriteLine("                 ");
                                            break;
                                    }

                                    if (keyInfo.Key == ConsoleKey.Q)
                                    {
                                        doItAgain = false;
                                    }

                                    else
                                    {
                                        Console.SetCursorPosition(left, top + 26);
                                        Console.Write(
                                            "Would you verify this change? Y/N :                                                                      ");

                                        Regex keySelectYoNRegex = new Regex(@"[YN]$");
                                        ConsoleKeyInfo keyYoN;
                                        do
                                        {
                                            Console.SetCursorPosition(left + 37, top + 26);
                                            keyYoN = Console.ReadKey(true);
                                        } while (!keySelectYoNRegex.IsMatch(
                                            keyYoN.Key.ToString()));

                                        if (keyYoN.Key == ConsoleKey.Y)
                                        {
                                            int successRow = db.SaveChanges();

                                            if (successRow > 0)
                                            {
                                                Console.SetCursorPosition(left, top + 10);
                                                Console.Write(" This Article is registered !");
                                                Thread.Sleep(2000);
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(left, top + 10);
                                                Console.Write(
                                                    " This Article didn't registered !");
                                                Thread.Sleep(2000);
                                            }

                                            Console.SetCursorPosition(left, top + 10);
                                            Console.WriteLine(
                                                "                                      ");
                                            Console.SetCursorPosition(left, top + 12);
                                            ProductPrintMethods.ProductsView();
                                            doItAgain = true;
                                        }
                                        else
                                        {
                                            doItAgain = true;
                                        }
                                    }
                                } while (keyOption);
                            }
                        }
                    }
                }
                else
                {
                    doItAgain = false;
                }

                if (keySelectEdit.Key.ToString() != "0")
                {
                    Console.Clear();

                    Console.SetCursorPosition(left + 2, top);
                    Console.Write("Do you wish to search for any other Article ? Y/N :");

                    Console.SetCursorPosition(left, top + 12);
                    ProductPrintMethods.ProductsView();

                    Regex answerRegex = new Regex(@"[YN]$");
                    ConsoleKeyInfo answer;
                    do
                    {
                        Console.SetCursorPosition(left + 53, top);
                        answer = Console.ReadKey(true);
                    } while (!answerRegex.IsMatch(answer.Key.ToString()));

                    doItAgain = answer.Key == ConsoleKey.Y;
                }
            } while (doItAgain);

            doItAgain = true;
            return doItAgain;
        }
    }
}
