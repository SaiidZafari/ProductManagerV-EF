using System;
using System.Text.RegularExpressions;
using System.Threading;
using ProductManagerV_EF.Model;

namespace ProductManagerV_EF.Domain.Product
{
    class AddProducts
    {
        public static bool AddProduct(int left, int top, AppDbContext db)
        {
            bool doItAgain;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(45, 1);
                Console.WriteLine(">>  Add Article  <<");

                Console.SetCursorPosition(left + 2, top);
                Console.WriteLine(
                    $"Please insert information for the felts below and press Enter.{"To Central Menu (Exit)",50}");

                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine($"{"Article number:",17}");

                Console.SetCursorPosition(left, top + 3);
                Console.WriteLine($"{"(A123B45)",16}");

                Console.SetCursorPosition(left + 40, top + 2);
                Console.WriteLine($"{"Material:",17}");

                Console.SetCursorPosition(left, top + 4);
                Console.WriteLine($"{"Name:",17}");

                Console.SetCursorPosition(left + 40, top + 4);
                Console.WriteLine($"{"Color:",17}");

                Console.SetCursorPosition(left, top + 6);
                Console.WriteLine($"{"Price:",17}");

                Console.SetCursorPosition(left + 40, top + 6);
                Console.WriteLine($"{"Description:",17}");


                Console.SetCursorPosition(left, top + 12);
                ProductPrintMethods.ProductsView();


                Regex articleNumberRegex =
                    new Regex(@"^[A-Za-z][0-9][0-9][0-9][a-zA-Z][0-9][0-9]$");
                string articleNumber;
                do
                {
                    Console.SetCursorPosition(left + 18, top + 2);
                    Console.WriteLine("                    ");
                    Console.SetCursorPosition(left + 18, top + 2);
                    articleNumber = Console.ReadLine()?.ToUpper();

                    if (articleNumber == "EXIT")
                    {
                        articleNumber = "Z999Z99";
                    }

                    foreach (var product in db.Products)
                    {
                        if (product.ArticleNumber == articleNumber)
                        {
                            Console.SetCursorPosition(left, top + 10);
                            Console.WriteLine("                                              ");
                            Console.SetCursorPosition(left, top + 10);
                            Console.Write(" This Article is already registered !");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(left, top + 10);
                            Console.WriteLine("                                      ");
                            articleNumber = "Invalid";
                        }
                    }


                    foreach (var product in db.Products)
                    {
                        if (product.ArticleNumber == articleNumber)
                        {
                            Console.SetCursorPosition(left, top + 10);
                            Console.WriteLine("                                              ");
                            Console.SetCursorPosition(left, top + 10);
                            Console.Write(" This Article is already registered !");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(left, top + 10);
                            Console.WriteLine("                                      ");
                            articleNumber = "Invalid";
                        }
                    }
                } while (!articleNumberRegex.IsMatch(articleNumber ?? string.Empty));

                if (articleNumber == "Z999Z99")
                {
                    doItAgain = true;
                    break;
                }


                Console.SetCursorPosition(left + 18, top + 2);
                Console.WriteLine(articleNumber);

                Model.Product products = new Model.Product(
                    articleNumber, 
                    ProductMethods.AddName(left, top), 
                    ProductMethods.AddMaterial(left, top), 
                    ProductMethods.AddColor(left, top), 
                    ProductMethods.AddPrice(left, top),
                    ProductMethods.AddDescription(left, top));

                db.Products.Add(products);

                //db.Products.Add(new Model.Product
                //{
                //    ArticleNumber = articleNumber,
                //    Name = ProductMethods.AddName(left, top),
                //    Price = ProductMethods.AddPrice(left, top),
                //    Material = ProductMethods.AddMaterial(left, top),
                //    Color = ProductMethods.AddColor(left, top),
                //    Description = ProductMethods.AddDescription(left, top)
                //});


                Console.SetCursorPosition(left, top + 10);
                Console.WriteLine($"Would you please confirm the Information above? Y/N ");


                Regex confirmRegex = new Regex(@"[YyNn]$");
                ConsoleKeyInfo confirm;
                do
                {
                    Console.SetCursorPosition(left + 52, top + 10);
                    confirm = Console.ReadKey(true);
                } while (!confirmRegex.IsMatch(confirm.KeyChar.ToString()));


                Console.SetCursorPosition(left, top + 10);
                Console.WriteLine($"                                                     ");

                if (confirm.Key == ConsoleKey.Y)
                {
                    int successRow = db.SaveChanges();
                    ProductMethods.MessageByAction(successRow, left, top, "Add");
                    doItAgain = true;
                }
                else
                {
                    doItAgain = true;
                }
            } while (doItAgain);

            return doItAgain;
        }
    }
}
